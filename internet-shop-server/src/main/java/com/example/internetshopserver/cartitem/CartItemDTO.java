package com.example.internetshopserver.cartitem;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class CartItemDTO {

    private Long id;
    private Integer cartItemCount;
    private Long ingredientId;
    private String ingredientName;
    private Double ingredientPrice;
}
