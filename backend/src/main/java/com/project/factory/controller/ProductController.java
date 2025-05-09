package com.project.factory.controller;


import com.project.factory.model.Product;
import com.project.factory.service.ProductService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/product")
public class ProductController
{

    @Autowired
    private ProductService productService;


    @GetMapping()
    private ResponseEntity<?> getProductsById(@RequestParam int categoryId)
    {
        List<Product> product = productService.getProductsById(categoryId);

        if(product == null)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(product);
    }


    @GetMapping("/all")
    @PreAuthorize("hasAuthority('ADMIN')")
    private ResponseEntity<?> getAllProducts()
    {
        List<Product> product = productService.getAllProducts();

        if(product == null)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(product);
    }

    @PostMapping("/add")
    @PreAuthorize("hasAuthority('ADMIN')")
    private ResponseEntity<?> addProduct(@RequestBody Product product)
    {
        Product addProduct = productService.addProduct(product);

        if(addProduct == null)
        {
            return ResponseEntity.badRequest().body("Product already exists");
        }
        return ResponseEntity.ok("Product added successfully");
    }

    @PostMapping("/update")
    @PreAuthorize("hasAuthority('ADMIN')")
    private ResponseEntity<?> updateProduct(@RequestBody Product product)
    {
        Product updatedProduct = productService.updateProduct(product);

        if(updatedProduct == null)
        {
            return ResponseEntity.badRequest().body("Product already exists");
        }
        return ResponseEntity.ok("Product updated successfully");
    }

    @DeleteMapping("/delete")
    @PreAuthorize("hasAuthority('ADMIN')")
    private ResponseEntity<?> deleteProduct(@RequestParam int productId)
    {
        boolean deleted = productService.deleteProduct(productId);

        if(!deleted)
        {
            return ResponseEntity.badRequest().body("Product not found");
        }
        return ResponseEntity.ok("Product deleted successfully");
    }

}
