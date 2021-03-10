package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.exceptions.CartItemNotFoundException;
import com.example.internetshopserver.exceptions.IngredientNotFoundException;
import com.example.internetshopserver.ingredient.Ingredient;
import com.example.internetshopserver.ingredient.IngredientRepository;
import lombok.AllArgsConstructor;
import org.postgresql.util.PSQLException;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.ResponseStatus;

import java.util.List;

@Service
@AllArgsConstructor
public class CartItemServiceImpl implements CartItemService {

    private final CartItemRepository cartItemRepository;
    private final IngredientRepository ingredientRepository;
    private final CartItemMapper cartItemMapper;

    @Override
    public List<CartItemDTO> getCartItemList() {
        return cartItemMapper.toCartItemDTOs(cartItemRepository.findAll());
    }

    @Override
    public CartItemDTO getCartItemById(Long id) {
        return cartItemMapper.toCartItemDTO(cartItemRepository.findById(id)
                .orElseThrow(CartItemNotFoundException::new));
    }

    @Override
    public CartItemDTO saveCartItem(Long id, CartItemDTO cartItemDTO) {
        CartItem modifiedCartItem = cartItemMapper.toCartItem(cartItemDTO);
        Ingredient ingredient = ingredientRepository.findById(cartItemDTO.getIngredientId())
                .orElseThrow(IngredientNotFoundException::new);
        modifiedCartItem.setIngredient(ingredient);
        if (id != null) {
            modifiedCartItem.setId(id);
        }
        return cartItemMapper.toCartItemDTO(cartItemRepository.save(modifiedCartItem));
    }

    @Override
    public void deleteCartItem(Long id) {
        cartItemRepository.deleteById(id);
    }

    @Override
    public void deleteByUserId(Long userId) {
        cartItemRepository.deleteAll();
    }

}
