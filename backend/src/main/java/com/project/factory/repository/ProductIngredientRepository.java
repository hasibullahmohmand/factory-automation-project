package com.project.factory.repository;

import com.project.factory.model.Ingredient;
import com.project.factory.model.ProductIngredient;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductIngredientRepository extends JpaRepository<ProductIngredient, Integer>
{

    @Modifying
    @Query("DELETE FROM ProductIngredient pi WHERE pi.product.id = :productId")
    int deleteByProductId(@Param("productId") int productId);


    @Query("SELECT pi.ingredient FROM ProductIngredient pi WHERE pi.product.id = :productId")
    List<ProductIngredient> findIngredientsByProductId(@Param("productId") int productId);

    @Query("SELECT p.product FROM  ProductIngredient p WHERE p.ingredient.id = :ingredientId")
    List<ProductIngredient> findProductsByIngredientId(@Param("ingredientId") int ingredientId);



}