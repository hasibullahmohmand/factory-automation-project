package com.project.factory.service;


import com.project.factory.model.Cart;
import com.project.factory.model.Order;
import com.project.factory.repository.CartRepository;
import com.project.factory.repository.OrderRepository;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.time.LocalDateTime;
import java.util.List;
import java.util.Optional;

@Service
public class OrderService
{
    @Autowired
    private OrderRepository orderRepository;

    @Autowired
    private CartRepository cartRepository;


    @Transactional
    public int addOrder(int cartId)
    {
        cartRepository.findById(cartId).orElseThrow(() -> new RuntimeException("Cart not found"));

        Optional<Order> order = orderRepository.findById(cartId);

        if (order.isPresent())
        {
            return order.get().getId();
        }

       return orderRepository.addOrderByCartId(cartId);
    }

    public List<Order> getOrder()
    {
        return orderRepository.findAll();
    }

    @Transactional
    public Order updateOrder(int orderId, String status)
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
        order.setDeliveryDate(LocalDateTime.now());
        return orderRepository.save(order);
    }
}
