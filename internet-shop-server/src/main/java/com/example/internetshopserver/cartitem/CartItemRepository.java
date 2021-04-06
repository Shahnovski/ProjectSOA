package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.ingredient.Ingredient;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface CartItemRepository extends JpaRepository<CartItem, Long> {
    List<CartItem> findByCartItemUserNameOrderById(String cartItemUserName);
    void deleteAllByCartItemUserName(String username);
    long countAllByCartItemUserName(String username);
    Optional<CartItem> findByCartItemUserNameAndIngredient(String username, Ingredient ingredient);
}
