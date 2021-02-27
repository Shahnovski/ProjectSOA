package com.example.ingredientscatalogserver.Ingredient;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.persistence.*;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "ingredient")
public class Ingredient {

    @Id
    @GeneratedValue
    @Column(name = "id", nullable = false)
    private Long id;

    @Column(name = "ingredientName", nullable = false)
    private String ingredientName;

    @Column(name = "ingredientCalories", nullable = false)
    private Double ingredientCalories;

    @Column(name = "ingredientProteins", nullable = false)
    private Double ingredientProteins;

    @Column(name = "ingredientCarbohydrates", nullable = false)
    private Double ingredientCarbohydrates;

    @Column(name = "ingredientFats", nullable = false)
    private Double ingredientFats;
}
