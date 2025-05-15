package com.project.factory.repository;

import com.project.factory.model.Cart;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.security.core.parameters.P;

import java.time.LocalDateTime;
import java.util.List;

public interface CartRepository extends JpaRepository<Cart, Integer>
{
    @Modifying
    @Query(value = "INSERT INTO cart (quantity,created_at, product_id, user_id) VALUES (:quantity, :createdAt , :productId, :userId)",
            nativeQuery = true)
    int createCart(@Param("quantity") int quantity, @Param("createdAt") LocalDateTime createdAt, @Param("productId") int productId, @Param("userId") int userId);


    @Modifying
    @Query(value = "UPDATE cart SET quantity = :quantity WHERE id = :cartId AND user_id = :id",
            nativeQuery = true)
    int updateCart(int cartId, int quantity, int id);


    @Modifying
    @Query(value = "UPDATE cart SET active = false WHERE id = :cartId", nativeQuery = true)
    void updateCartStatus(int cartId);


    @Query(value = "SELECT * FROM cart WHERE user_id = :userId", nativeQuery = true)
    List<Cart> findAllByUserId(int userId);
}
