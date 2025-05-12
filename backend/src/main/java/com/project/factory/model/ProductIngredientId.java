package com.project.factory.model;

import jakarta.persistence.Column;
import jakarta.persistence.Embeddable;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.io.Serializable;

@Embeddable
@Data
@NoArgsConstructor
@AllArgsConstructor
public class ProductIngredientId implements Serializable
{

    @Column(name = "product_id")
    private Integer productId;

    @Column(name = "ingredient_id")
    private Integer ingredientId;
}
