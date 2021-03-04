package com.example.ingredientscatalogserver.ingredient;

import java.util.List;

public interface IngredientService {
    List<IngredientDTO> getIngredientList();

    IngredientDTO getIngredientById(Long id);

    IngredientDTO saveIngredient(Long id, IngredientDTO ingredientDTO);

    void deleteIngredient(Long id);
}
