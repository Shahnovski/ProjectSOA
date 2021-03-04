package com.example.ingredientscatalogserver.ingredient;

import com.example.ingredientscatalogserver.exceptions.IngredientCodeExistsException;
import com.example.ingredientscatalogserver.exceptions.IngredientNotFoundException;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
@AllArgsConstructor
public class IngredientServiceImpl implements IngredientService{

    private final IngredientRepository ingredientRepository;
    private final IngredientMapper ingredientMapper;

    @Override
    public List<IngredientDTO> getIngredientList() {
        return ingredientMapper.toIngredientDTOs(ingredientRepository.findAll());
    }

    @Override
    public IngredientDTO getIngredientById(Long id) {
        return ingredientMapper.toIngredientDTO(ingredientRepository.findById(id)
                .orElseThrow(IngredientNotFoundException::new));
    }

    @Override
    public IngredientDTO saveIngredient(Long id, IngredientDTO ingredientDTO) {
        Ingredient modifiedIngredient = ingredientMapper.toIngredient(ingredientDTO);
        Ingredient byIngredientCode = ingredientRepository.findByIngredientCode(modifiedIngredient.getIngredientCode());
        if (byIngredientCode != null && !byIngredientCode.getId().equals(id)) {
            throw new IngredientCodeExistsException();
        }
        if (id != null) {
            modifiedIngredient.setId(id);
        }
        return ingredientMapper.toIngredientDTO(ingredientRepository.save(modifiedIngredient));
    }

    @Override
    public void deleteIngredient(Long id) {
        ingredientRepository.deleteById(id);
    }
}
