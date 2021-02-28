package com.example.ingredientscatalogserver.ingredient;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface IngredientRepository extends JpaRepository<Ingredient, Long> {
    List<Ingredient> findAll();
    Ingredient findByIngredientCode(Long ingredientCode);
}
