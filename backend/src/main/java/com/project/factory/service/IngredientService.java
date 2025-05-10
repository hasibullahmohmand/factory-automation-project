package com.project.factory.service;


import com.project.factory.model.Ingredient;
import com.project.factory.repository.IngredientRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class IngredientService
{

    @Autowired
    private IngredientRepository ingredientRepository;

    public List<Ingredient> getAllIngredients()
    {
        return ingredientRepository.findAll();
    }


    public Ingredient addIngredient(Ingredient ingredient)
    {
        if (ingredientRepository.existsByName(ingredient.getName()))
        {
            return null;
        }

        ingredient.setId(null);

        return ingredientRepository.save(ingredient);
    }
}
