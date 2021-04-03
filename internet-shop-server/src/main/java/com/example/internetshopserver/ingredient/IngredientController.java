package com.example.internetshopserver.ingredient;

import com.example.internetshopserver.common.ApplicationProperties;
import com.example.internetshopserver.config.jwt.JwtFilter;
import com.example.internetshopserver.config.jwt.JwtProvider;
import com.example.internetshopserver.exceptions.IngredientCodeExistsException;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.security.access.AccessDeniedException;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;
import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.INGREDIENT_API_URL)
public class IngredientController {

    private final IngredientService ingredientService;
    private final JwtProvider jwtProvider;
    private final JwtFilter jwtFilter;

    @GetMapping(value = "", produces = "application/json; charset=UTF-8")
    List<IngredientDTO> getIngredientList() {
        return ingredientService.getIngredientList();
    }

    @GetMapping(value = "/byCodes/", params = "codes", produces = "application/json; charset=UTF-8")
    List<IngredientDTO> getIngredientListByCodes(@RequestParam(value = "codes") List<Long> codes) {
        return ingredientService.getIngredientListByCodes(codes);
    }

    @GetMapping("/{id}")
    IngredientDTO getIngredientById(@PathVariable(value = "id") Long ingredientId) {
        return ingredientService.getIngredientById(ingredientId);
    }

    @PostMapping("")
    IngredientDTO createIngredient(@RequestBody IngredientDTO ingredientDTO, HttpServletRequest request) {
        String role = jwtProvider.getRoleFromToken(jwtFilter.getTokenFromRequest(request));
        if (!role.equals("admin"))
        {
            throw new AccessDeniedException("Access denied!");
        }
        return ingredientService.saveIngredient(null, ingredientDTO);
    }

    @PutMapping("/{id}")
    public IngredientDTO updateIngredient(@PathVariable(value = "id") Long ingredientId,
                                          @RequestBody IngredientDTO ingredientDTO,
                                          HttpServletRequest request) {
        String role = jwtProvider.getRoleFromToken(jwtFilter.getTokenFromRequest(request));
        if (!role.equals("admin"))
        {
            throw new AccessDeniedException("Access denied!");
        }
        return ingredientService.saveIngredient(ingredientId, ingredientDTO);
    }

    @DeleteMapping("/{id}")
    public void deleteIngredient(@PathVariable(value = "id") Long ingredientId, HttpServletRequest request) {
        String role = jwtProvider.getRoleFromToken(jwtFilter.getTokenFromRequest(request));
        if (!role.equals("admin"))
        {
            throw new AccessDeniedException("Access denied!");
        }
        ingredientService.deleteIngredient(ingredientId);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(IngredientCodeExistsException.class)
    public String handleValidationExceptions(IngredientCodeExistsException ex) {
        return "This ingredientCode is already exists!";
    }
}

