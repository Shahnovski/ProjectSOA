package com.example.ingredientscatalogserver.Ingredient;

import org.mapstruct.Mapper;

import java.util.List;

@Mapper(componentModel = "spring")
public interface IngredientMapper {
    IngredientDTO toIngredientDTO(Ingredient ingredient);

    List<IngredientDTO> toIngredientDTOs(List<Ingredient> ingredient);

    Ingredient toIngredient(IngredientDTO ingredientDTO);
}
