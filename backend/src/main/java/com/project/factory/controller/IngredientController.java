package com.project.factory.controller;


import com.project.factory.model.Ingredient;
import com.project.factory.service.IngredientService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/ingredient")
public class IngredientController
{

    @Autowired
    private IngredientService ingredientService;


    @GetMapping
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getAllIngredients()
    {
        List<Ingredient> ingredients = ingredientService.getAllIngredients();

        if (ingredients == null)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(ingredients);
    }


    @PostMapping("/add")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> addIngredient(@RequestBody Ingredient ingredient)
    {
        Ingredient addedIngredient = ingredientService.addIngredient(ingredient);

        if (addedIngredient == null)
        {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok(addedIngredient);
    }
}
