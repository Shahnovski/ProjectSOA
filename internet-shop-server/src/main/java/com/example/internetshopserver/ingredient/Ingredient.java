package com.example.internetshopserver.ingredient;

import com.example.internetshopserver.cartitem.CartItem;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;
import javax.persistence.*;
import java.util.List;

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

    @Column(name = "ingredientCode", nullable = false, unique = true)
    private Long ingredientCode;

    @Column(name = "ingredientName", nullable = false)
    private String ingredientName;

    @Column(name = "ingredientPrice", nullable = false)
    private Double ingredientPrice;

    @OneToMany(mappedBy = "ingredient", cascade = CascadeType.REMOVE, fetch = FetchType.LAZY)
    private List<CartItem> cartItems;

}

