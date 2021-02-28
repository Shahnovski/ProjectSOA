package com.example.ingredientscatalogserver.ingredient;

import com.example.ingredientscatalogserver.common.ApplicationProperties;
import com.example.ingredientscatalogserver.exceptions.IngredientCodeExistsException;
import lombok.AllArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@AllArgsConstructor
@RequestMapping(ApplicationProperties.INGREDIENT_API_URL)
public class IngredientController {

    private final IngredientService ingredientService;

    @GetMapping(value = "", produces = "application/json; charset=UTF-8")
    List<IngredientDTO> getIngredientList() {
        return ingredientService.getIngredientList();
    }

    @GetMapping("/{id}")
    IngredientDTO getIngredientById(@PathVariable(value = "id") Long ingredientId) {
        return ingredientService.getIngredientById(ingredientId);
    }

    @PostMapping("")
    IngredientDTO createIngredient(@RequestBody IngredientDTO ingredientDTO) {
        return ingredientService.saveIngredient(null, ingredientDTO);
    }

    @PutMapping("/{id}")
    public IngredientDTO updateIngredient(@PathVariable(value = "id") Long ingredientId,
                            @RequestBody IngredientDTO ingredientDTO) {
        return ingredientService.saveIngredient(ingredientId, ingredientDTO);
    }

    @DeleteMapping("/{id}")
    public void deleteIngredient(@PathVariable(value = "id") Long ingredientId) {
        ingredientService.deleteIngredient(ingredientId);
    }

    @ResponseStatus(HttpStatus.BAD_REQUEST)
    @ExceptionHandler(IngredientCodeExistsException.class)
    public String handleValidationExceptions(IngredientCodeExistsException ex) {
        return "This ingredientCode is already exists!";
    }
}
