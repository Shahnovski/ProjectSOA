package com.example.ingredientscatalogserver.ingredient;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Collection;
import java.util.List;

public interface IngredientRepository extends JpaRepository<Ingredient, Long> {
    List<Ingredient> findAll();
    List<Ingredient> findByIngredientCodeIn(Collection<Long> codes);
    Ingredient findByIngredientCode(Long ingredientCode);
}
