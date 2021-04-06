using AutoMapper;
using MenuServer.Dtos;
using MenuServer.Models;
using MenuServer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MenuServer.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public IngredientService(
            IIngredientRepository ingredientRepository,
            IMapper mapper
            )
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public IngredientDto GetById(int id)
        {
            return _mapper.Map<IngredientDto>(_ingredientRepository.FindById(id, false));
        }
        
        public IngredientDto Save(int id, IngredientDto dto)
        {
            Ingredient ingredient = _mapper.Map<Ingredient>(dto);

            if (id != 0)
            {
                ingredient.IngredientId = id;
                _ingredientRepository.Update(ingredient);
            } else
            {
                _ingredientRepository.Add(ingredient);
            }

            ingredient = _ingredientRepository.Save(ingredient);
            return _mapper.Map<IngredientDto>(ingredient);
        }

        public void Delete(int id)
        {
            Ingredient ingredient = _ingredientRepository.FindById(id, false);
            _ingredientRepository.Delete(ingredient);
            _ingredientRepository.Save(ingredient);
        }

        public bool EntityExists(int id)
        {
            return _ingredientRepository.EntityExists(id);
        }

        public bool CodeExists(int code)
        {
            return _ingredientRepository.CodeExists(code);
        }

        public IEnumerable<IngredientDto> GetAll()
        {
            return _ingredientRepository.FindAll().Select(c => _mapper.Map<IngredientDto>(c));
        }
    }
}
