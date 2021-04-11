package com.example.internetshopserver.cartitem;

import java.util.List;

public interface CartItemService {
    List<CartItemDTO> getCartItemList(String username);

    CartItemDTO getCartItemById(Long id);

    CartItemDTO saveCartItem(Long id, CartItemDTO cartItemDTO);

    void deleteCartItem(Long id);

    void deleteByUserId(String username);
    
    Long getCartItemsCountByUserId(String username);

    void saveAllCartItems(List<CartItemFromMenuDTO> cartItemDTOs, String username);
}
