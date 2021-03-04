using AutoMapper;
using BankServer.Dtos;
using BankServer.Exceptions;
using BankServer.Models;
using BankServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankServer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public IEnumerable<AccountDto> GetAll()
        {
            return _accountRepository.FindAll().Select(a => _mapper.Map<AccountDto>(a));
        }

        public AccountDto GetById(int id)
        {
            return _mapper.Map<AccountDto>(_accountRepository.FindById(id));
        }

        public AccountDto Save(int id, AccountDto dto)
        {
            Account account = _mapper.Map<Account>(dto);
            if (id != 0)
            {
                account.AccountId = id;
                account.AccountMoney += _accountRepository.FindById(id).AccountMoney;
                if (account.AccountMoney < 0)
                {
                    throw new NotEnoughMoneyException();
                }
                _accountRepository.Update(account);
            }
            else
            {
                account.AccountMoney = 0;
                _accountRepository.Add(account);
            }
            return _mapper.Map<AccountDto>(_accountRepository.Save(account));
        }

        public void Delete(int id)
        {
            Account account = _accountRepository.FindById(id);
            _accountRepository.Delete(account);
            _accountRepository.Save(account);
        }

        public bool EntityExists(int id)
        {
            return _accountRepository.EntityExists(id);
        }
    }
}
