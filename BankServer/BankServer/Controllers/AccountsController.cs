using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankServer.Models;
using BankServer.Services;
using BankServer.Dtos;
using BankServer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using BankServer.Data;
using System.Security.Claims;

namespace BankServer.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/Accounts
        [HttpGet]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IEnumerable<AccountDto> GetAccountsByUsername()
        {
            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return _accountService.GetByUsername(currentUserName);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<AccountDto> GetAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AccountDto accountDto = _accountService.GetById(id);

            if (accountDto == null)
            {
                return NotFound();
            }

            return Ok(accountDto);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IActionResult PutAccount([FromRoute] int id, [FromBody] AccountDto accountDto)
        {
            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountDto.AccountId || !currentUserName.Equals(accountDto.AccountUserName))
            {
                return BadRequest();
            }

            try
            {
                accountDto = _accountService.Save(id, accountDto);
            }
            catch (NotEnoughMoneyException)
            {
                return BadRequest("Not enough money in the account!");
            }

            if (!AccountExists(id))
            {
                return NotFound();
            }

            return Ok(accountDto);
        }

        // PUT: api/Accounts/byNumber/00001234
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("byNumber/{number}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public IActionResult PutAccountByNumber([FromRoute] string number, [FromBody] AccountDto accountDto)
        {
            var currentUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!number.Equals(accountDto.AccountNumber))
            {
                return BadRequest();
            }

            AccountDto findedByNumberAccountDto;

            try
            {
                findedByNumberAccountDto = _accountService.GetByNumber(accountDto.AccountNumber);
                if (findedByNumberAccountDto != null && currentUserName.Equals(findedByNumberAccountDto.AccountUserName))
                {
                    findedByNumberAccountDto.AccountMoney = accountDto.AccountMoney;
                    findedByNumberAccountDto = _accountService.Save(findedByNumberAccountDto.AccountId, findedByNumberAccountDto);
                }
                else
                {
                    return NotFound("Account not found!");
                }
            }

            catch (NotEnoughMoneyException)
            {
                return BadRequest("Not enough money in the account!");
            }

            return Ok(findedByNumberAccountDto);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<AccountDto> PostAccount([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            accountDto.AccountUserName = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            AccountDto newAccount = _accountService.Save(0, accountDto);

            return CreatedAtAction("GetAccount", new { id = newAccount.AccountId }, newAccount);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.User, AuthenticationSchemes = "Bearer")]
        public ActionResult<AccountDto> DeleteAccount([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!AccountExists(id))
            {
                return NotFound();
            }

            _accountService.Delete(id);

            return Ok();
        }

        private bool AccountExists(int id)
        {
            return _accountService.EntityExists(id);
        }
    }
}
