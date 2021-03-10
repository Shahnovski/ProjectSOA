package com.example.internetshopserver.cartitem;

import org.mapstruct.Mapper;
import org.mapstruct.Mapping;

import java.util.List;

@Mapper(componentModel = "spring")
public interface CartItemMapper {

    @Mapping(source = "ingredient.id", target = "ingredientId")
    @Mapping(source = "ingredient.ingredientName", target = "ingredientName")
    @Mapping(source = "ingredient.ingredientPrice", target = "ingredientPrice")
    CartItemDTO toCartItemDTO(CartItem cartItem);

    List<CartItemDTO> toCartItemDTOs(List<CartItem> cartItem);

    CartItem toCartItem(CartItemDTO cartItemDTO);
}
