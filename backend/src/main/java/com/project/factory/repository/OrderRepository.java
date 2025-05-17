package com.project.factory.repository;

import com.project.factory.dto.PendingOrderDTO;
import com.project.factory.model.Order;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

import java.time.LocalDateTime;
import java.util.List;


public interface OrderRepository extends JpaRepository<Order, Integer>
{

    @Modifying
    @Query(value = "INSERT INTO orders (cart_id , order_date) VALUES (:cartId ,:orderDate)",nativeQuery = true)
    int addOrderByCartId(int cartId,LocalDateTime orderDate);

    @Query(value = "SELECT * FROM orders WHERE cart_id = :id",nativeQuery = true)
    Order findByCartId(Integer id);

//    @Query(value = "SELECT o.id, u.username, o.delivered, o.order_date " +
//            "FROM factory.orders o " +
//            "LEFT JOIN factory.cart c ON o.cart_id = c.id " +
//            "LEFT JOIN factory.user u ON c.user_id = u.id " +
//            "WHERE o.delivered = true", nativeQuery = true)
//    List<Object[]> findPendingOrdersNative();

    @Query("SELECT new com.project.factory.dto.PendingOrderDTO(o.id, u.username, o.delivered, o.orderDate) " +
            "FROM Order o " +
            "LEFT JOIN o.cart c " +
            "LEFT JOIN c.user u " +
            "WHERE o.delivered = false")
    List<PendingOrderDTO> findPendingOrders();

    @Query(value = "SELECT p.name, COUNT(*) AS order_count " +
            "FROM factory.orders o " +
            "JOIN factory.product p ON o.id = p.id " +
            "GROUP BY p.name " +
            "ORDER BY order_count DESC " +
            "LIMIT 5", nativeQuery = true)
    List<Object[]> findTopOrderedProducts();
}
