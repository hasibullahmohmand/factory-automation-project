package com.project.factory.service;


import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.project.factory.model.Ingredient;
import com.project.factory.repository.IngredientRepository;

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
    
    public Ingredient updateIngredient(Ingredient ingredient)
    {
        if(ingredientRepository.existsById(ingredient.getId()))
            return ingredientRepository.save(ingredient);
        return null;
    }
    public int deleteIngredient(int ingredientId)
    {
        if(ingredientRepository.existsById(ingredientId))
        {
            ingredientRepository.deleteById(ingredientId);
            return 1;
        }
        return 0;
    }

}
