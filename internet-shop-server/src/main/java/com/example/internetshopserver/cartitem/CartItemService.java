package com.example.internetshopserver.cartitem;

import org.postgresql.util.PSQLException;

import java.util.List;

public interface CartItemService {
    List<CartItemDTO> getCartItemList();

    CartItemDTO getCartItemById(Long id);

    CartItemDTO saveCartItem(Long id, CartItemDTO cartItemDTO);

    void deleteCartItem(Long id);

    void deleteByUserId(Long userId);
    
    Long getCartItemsCountByUserId(Long userId);
}
