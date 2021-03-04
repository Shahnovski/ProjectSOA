package com.example.internetshopserver.ingredient;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class IngredientDTO {

    private Long id;
    private Long ingredientCode;
    private String ingredientName;
    private Double ingredientPrice;

}

