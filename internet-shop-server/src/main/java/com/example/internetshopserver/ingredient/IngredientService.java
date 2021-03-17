package com.example.internetshopserver.ingredient;

import java.util.List;

public interface IngredientService {
    List<IngredientDTO> getIngredientList();

    List<IngredientDTO> getIngredientListByCodes(List<Long> codes);

    IngredientDTO getIngredientById(Long id);

    IngredientDTO saveIngredient(Long id, IngredientDTO ingredientDTO);

    void deleteIngredient(Long id);
}

