package com.project.factory.service;


import com.project.factory.dto.TopProductDTO;
import com.project.factory.model.Product;
import com.project.factory.model.ProductIngredient;
import com.project.factory.model.ProductIngredientId;
import com.project.factory.repository.IngredientRepository;
import com.project.factory.repository.ProductIngredientRepository;
import com.project.factory.repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

@Service
public class ProductService
{
    @Autowired
    private ProductRepository productRepository;

    @Autowired
    private ProductIngredientRepository productIngredientRepository;

    @Autowired
    private IngredientRepository ingredientRepository;

    public List<Product> getProductsById(int id)
    {
        return productRepository.findProductsByCategoryId(id);
    }

    public Product addProduct(Product product)
    {
        if (productRepository.existsById(product.getId()))
        {
            return null;
        }

        product.setId(null);

        return productRepository.save(product);
    }

    public Product updateProduct(Product product)
    {
        if (!productRepository.existsById(product.getId()))
        {
            return null;
        }

        return productRepository.save(product);
    }

    public List<Product> getAllProducts()
    {
        return productRepository.findAll();
    }

    @Transactional
    public boolean deleteProduct(int productId)
    {

       int product_delete =  productIngredientRepository.deleteByProductId(productId);

        if (!productRepository.existsById(productId))
        {
            return false;
        }

        productRepository.deleteById(productId);
        return true;
    }

    @Transactional
    public Product addProductWithIngredients(Product product, List<Integer> ingredientIds) {
        if (productRepository.existsByName(product.getName()))
        {
            return null;
        }

        if (ingredientIds == null || ingredientIds.isEmpty())
        {
            return null;
        }


        for (Integer ingredientId : ingredientIds)
        {
            if (!ingredientRepository.existsById(ingredientId))
            {
                return null;
            }
        }

        product.setId(null);
        Product savedProduct = productRepository.save(product);


        for (Integer ingredientId : ingredientIds)
        {
            ProductIngredient pi = new ProductIngredient();
            ProductIngredientId id = new ProductIngredientId(savedProduct.getId(), ingredientId);
            pi.setId(id);

            pi.setProduct(savedProduct);
            pi.setIngredient(ingredientRepository.findById(ingredientId).get());
            productIngredientRepository.save(pi);
        }

        return savedProduct;
    }


}
