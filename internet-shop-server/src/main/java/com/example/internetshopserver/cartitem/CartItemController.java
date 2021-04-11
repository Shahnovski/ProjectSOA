package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.common.ApplicationProperties;
import com.example.internetshopserver.config.jwt.JwtFilter;
import com.example.internetshopserver.config.jwt.JwtProvider;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.security.access.AccessDeniedException;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;
import java.util.ArrayList;
import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.CART_ITEM_API_URL)
public class CartItemController {

    private final CartItemService cartItemService;
    private final JwtProvider jwtProvider;
    private final JwtFilter jwtFilter;

    @GetMapping(value = "", produces = "application/json; charset=UTF-8")
    List<CartItemDTO> getCartItemList(HttpServletRequest request) {
        String username = jwtProvider.getLoginFromToken(jwtFilter.getTokenFromRequest(request));
        return cartItemService.getCartItemList(username);
    }

    @GetMapping("/{id}")
    CartItemDTO getCartItemById(@PathVariable(value = "id") Long cartItemId) {
        return cartItemService.getCartItemById(cartItemId);
    }

    @PostMapping("")
    CartItemDTO createCartItem(@RequestBody CartItemDTO cartItemDTO, HttpServletRequest request) {
        String username = jwtProvider.getLoginFromToken(jwtFilter.getTokenFromRequest(request));
        cartItemDTO.setCartItemUserName(username);
        return cartItemService.saveCartItem(null, cartItemDTO);
    }

    @PutMapping("/{id}")
    public CartItemDTO updateCartItem(@PathVariable(value = "id") Long cartItemId,
                                          @RequestBody CartItemDTO cartItemDTO,
                                      HttpServletRequest request) {
        String username = jwtProvider.getLoginFromToken(jwtFilter.getTokenFromRequest(request));
        if (!username.equals(cartItemDTO.getCartItemUserName()))
        {
            throw new AccessDeniedException("Access denied!");
        }
        return cartItemService.saveCartItem(cartItemId, cartItemDTO);
    }

    @DeleteMapping("/{id}")
    public void deleteCartItem(@PathVariable(value = "id") Long cartItemId) {
        cartItemService.deleteCartItem(cartItemId);
    }

    @DeleteMapping("/deleteByUserId/{username}")
    public void deleteCartItemsByUserId(@PathVariable(value = "username") String username) {
        cartItemService.deleteByUserId(username);
    }

    @GetMapping("/cartItemsCount/{username}")
    public Long getCartItemsCountByUserId(@PathVariable(value = "username") String username) {
        return cartItemService.getCartItemsCountByUserId(username);
    }

    @PostMapping("/all")
    public void createAllCartItems(@RequestBody ArrayList<CartItemFromMenuDTO> cartItemDTOs,
                                   HttpServletRequest request) {
        String username = jwtProvider.getLoginFromToken(jwtFilter.getTokenFromRequest(request));
        cartItemService.saveAllCartItems(cartItemDTOs, username);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(org.postgresql.util.PSQLException.class)
    public String handleValidationExceptions(org.postgresql.util.PSQLException ex) {
        return ex.getMessage();
    }
}
