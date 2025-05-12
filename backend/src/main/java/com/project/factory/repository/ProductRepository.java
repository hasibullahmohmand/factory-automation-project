package com.project.factory.repository;


import com.project.factory.model.Product;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ProductRepository extends JpaRepository<Product, Integer>
{

    @Query("SELECT p FROM Product p WHERE p.category.id = :id")
    List<Product> findProductsByCategoryId(@Param("id") int id);


    @Modifying
    @Query("UPDATE Product p SET p.stock = p.stock - :quantity WHERE p.id = :id")
    void updateStock(@Param("quantity") int quantity, @Param("id") int id);

    @Query("SELECT CASE WHEN COUNT(p) > 0 THEN true ELSE false END FROM Product p WHERE p.name = :name")
    boolean existsByName(String name);

}
