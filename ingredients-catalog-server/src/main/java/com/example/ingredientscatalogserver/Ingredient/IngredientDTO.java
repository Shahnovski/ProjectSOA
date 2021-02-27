package com.example.ingredientscatalogserver.Ingredient;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class IngredientDTO {

    private Long id;
    private String ingredientName;
    private Double ingredientCalories;
    private Double ingredientProteins;
    private Double ingredientCarbohydrates;
    private Double ingredientFats;
}
