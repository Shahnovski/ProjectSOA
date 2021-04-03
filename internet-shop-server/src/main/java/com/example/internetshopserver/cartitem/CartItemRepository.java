package com.example.internetshopserver.cartitem;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface CartItemRepository extends JpaRepository<CartItem, Long> {
    List<CartItem> findByCartItemUserNameOrderById(String cartItemUserName);
    void deleteAllByCartItemUserName(String username);
    long countAllByCartItemUserName(String username);
}
