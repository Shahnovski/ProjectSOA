package com.example.internetshopserver.cartitem;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CartItemFromMenuDTO {

    private Long ingredientCode;
    private Integer cartItemCount;
}
