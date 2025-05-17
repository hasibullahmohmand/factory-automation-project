package com.project.factory.repository;

import com.project.factory.model.Order;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

import java.time.LocalDateTime;


public interface OrderRepository extends JpaRepository<Order, Integer>
{

    @Modifying
    @Query(value = "INSERT INTO orders (cart_id , order_date) VALUES (:cartId ,:orderDate)",nativeQuery = true)
    int addOrderByCartId(int cartId,LocalDateTime orderDate);

    @Query(value = "SELECT * FROM orders WHERE cart_id = :id",nativeQuery = true)
    Order findByCartId(Integer id);
}
