package com.project.factory.repository;

import com.project.factory.model.Ingredient;
import org.springframework.data.jpa.repository.JpaRepository;

public interface IngredientRepository extends JpaRepository<Ingredient, Integer>
{

    boolean existsByName(String name);
}
