package com.example.internetshopserver.cartitem;

import com.example.internetshopserver.exceptions.CartItemNotFoundException;
import com.example.internetshopserver.exceptions.IngredientNotFoundException;
import com.example.internetshopserver.ingredient.Ingredient;
import com.example.internetshopserver.ingredient.IngredientRepository;
import lombok.AllArgsConstructor;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
@AllArgsConstructor
public class CartItemServiceImpl implements CartItemService {

    private final CartItemRepository cartItemRepository;
    private final IngredientRepository ingredientRepository;
    private final CartItemMapper cartItemMapper;

    @Override
    public List<CartItemDTO> getCartItemList(String username) {
        return cartItemMapper.toCartItemDTOs(cartItemRepository.findByCartItemUserNameOrderById(username));
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

    @Transactional
    @Override
    public void deleteByUserId(String username) {
        cartItemRepository.deleteAllByCartItemUserName(username);
    }

    @Override
    public Long getCartItemsCountByUserId(String username) {
        return cartItemRepository.countAllByCartItemUserName(username);
    }

    @Override
    public void saveAllCartItems(List<CartItemFromMenuDTO> cartItemDTOs, String username) {
        cartItemDTOs.forEach( cartItemDTO -> {
            CartItem cartItem = new CartItem();
            cartItem.setCartItemCount(cartItemDTO.getCartItemCount());
            Ingredient ingredient = ingredientRepository.findByIngredientCode(cartItemDTO.getIngredientCode());
            cartItem.setIngredient(ingredient);
            cartItem.setCartItemUserName(username);
            try {
                CartItem existCartItem =
                        cartItemRepository.findByCartItemUserNameAndIngredient(username, ingredient)
                        .orElseThrow(CartItemNotFoundException::new);
                existCartItem.setCartItemCount(existCartItem.getCartItemCount() + cartItem.getCartItemCount());
                cartItemRepository.save(existCartItem);
            }
            catch (CartItemNotFoundException ex) {
                cartItemRepository.save(cartItem);
            }
        });
    }

}
