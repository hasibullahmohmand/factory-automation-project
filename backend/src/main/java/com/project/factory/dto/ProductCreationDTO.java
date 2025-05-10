package com.project.factory.dto;
import com.project.factory.model.Product;
import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.util.List;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
public class ProductCreationDTO
{
    private Product product;
    private List<Integer> ingredientIds;
}
