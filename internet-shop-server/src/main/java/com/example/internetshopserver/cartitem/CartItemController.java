package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.common.ApplicationProperties;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.CART_ITEM_API_URL)
public class CartItemController {

    private final CartItemService cartItemService;

    @GetMapping(value = "", produces = "application/json; charset=UTF-8")
    List<CartItemDTO> getCartItemList() {
        return cartItemService.getCartItemList();
    }

    @GetMapping("/{id}")
    CartItemDTO getCartItemById(@PathVariable(value = "id") Long cartItemId) {
        return cartItemService.getCartItemById(cartItemId);
    }

    @PostMapping("")
    CartItemDTO createCartItem(@RequestBody CartItemDTO cartItemDTO) {
        return cartItemService.saveCartItem(null, cartItemDTO);
    }

    @PutMapping("/{id}")
    public CartItemDTO updateCartItem(@PathVariable(value = "id") Long cartItemId,
                                          @RequestBody CartItemDTO cartItemDTO) {
        return cartItemService.saveCartItem(cartItemId, cartItemDTO);
    }

    @DeleteMapping("/{id}")
    public void deleteCartItem(@PathVariable(value = "id") Long cartItemId) {
        cartItemService.deleteCartItem(cartItemId);
    }

    @DeleteMapping("/deleteByUserId/{userId}")
    public void deleteCartItemsByUserId(@PathVariable(value = "userId") Long userId) {
        cartItemService.deleteByUserId(userId);
    }

    @GetMapping("/cartItemsCount/{userId}")
    public Long getCartItemsCountByUserId(@PathVariable(value = "userId") Long userId) {
        return cartItemService.getCartItemsCountByUserId(userId);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(org.postgresql.util.PSQLException.class)
    public String handleValidationExceptions(org.postgresql.util.PSQLException ex) {
        return ex.getMessage();
    }
}
