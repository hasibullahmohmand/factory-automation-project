package com.project.factory.repository;

import com.project.factory.model.Order;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;


public interface OrderRepository extends JpaRepository<Order, Integer>
{

    @Modifying
    @Query(value = "INSERT INTO orders (cart_id) VALUES (:cartId)",nativeQuery = true)
    int addOrderByCartId(int cartId);

}
