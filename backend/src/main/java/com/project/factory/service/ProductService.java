package com.project.factory.service;


import com.project.factory.model.Product;
import com.project.factory.repository.ProductRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ProductService
{
    @Autowired
    private ProductRepository productRepository;

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

    public boolean deleteProduct(int productId)
    {
        if (!productRepository.existsById(productId))
        {
            return false;
        }

        productRepository.deleteById(productId);
        return true;
    }
}
