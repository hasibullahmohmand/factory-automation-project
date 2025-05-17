package com.project.factory.service;


import com.project.factory.dto.PendingOrderDTO;
import com.project.factory.dto.TopProductDTO;
import com.project.factory.model.Cart;
import com.project.factory.model.Order;
import com.project.factory.repository.CartRepository;
import com.project.factory.repository.OrderRepository;

import com.project.factory.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Optional;
import java.util.stream.Collectors;

@Service
public class OrderService
{
    @Autowired
    private OrderRepository orderRepository;

    @Autowired
    private CartRepository cartRepository;

    @Autowired
    private UserRepository userRepository;


    @Transactional
    public int addOrder(int cartId)
    {
        cartRepository.findById(cartId).orElseThrow(() -> new RuntimeException("Cart not found"));

        Optional<Order> order = orderRepository.findById(cartId);

        if (order.isPresent())
        {
            return order.get().getId();
        }

        LocalDateTime orderDate = LocalDateTime.now();

       return orderRepository.addOrderByCartId(cartId , orderDate);
    }

    public List<Order> getOrder()
    {
        return orderRepository.findAll();
    }

    @Transactional
    public Order updateOrder(int orderId, String status , LocalDateTime deliveryDate)
    {

        Order order = orderRepository.findById(orderId).orElseThrow(() -> new RuntimeException("Order not found"));

        if(order == null)
        {
            return null;
        }

        int cartId = order.getCart().getId();
        cartRepository.updateCartStatus(cartId);

        boolean statusBool = Boolean.parseBoolean(status);

        order.setDelivered(statusBool);

        order.setDeliveryDate(Objects.requireNonNullElseGet(deliveryDate, LocalDateTime::now));

        return orderRepository.save(order);
    }

    public List<Order> getOrderById(String username)
    {
        int userId = userRepository.findUserIdByEmail(username);

        List<Cart> cart = cartRepository.findAllByUserId(userId);

        if (cart == null)
        {
            return null;
        }

        List<Order> orders = new ArrayList<>();

        for (Cart c : cart)
        {
            Order order = orderRepository.findByCartId(c.getId());
            if (order != null)
            {
                orders.add(order);
            }
        }

        return orders;
    }

    public List<PendingOrderDTO> getPendingOrders()
    {
        return orderRepository.findPendingOrders();
    }

    public List<TopProductDTO> getTopOrderedProducts()
    {
        List<Object[]> results = orderRepository.findTopOrderedProducts();
        return results.stream()
                .map(row -> new TopProductDTO(
                        (String) row[0],
                        ((Number) row[1]).longValue()))
                .collect(Collectors.toList());
    }

    public Double getDeliveredOrdersRevenue()
    {
        return orderRepository.getDeliveredOrdersRevenue();
    }
}
