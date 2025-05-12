package com.project.factory.controller;


import com.project.factory.service.OrderService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.util.Map;

@RestController
@RequestMapping("/order")
public class OrderController
{

    @Autowired
    private OrderService orderService;

    @PostMapping("/add")
    public ResponseEntity<?> addOrder(@RequestBody Map<String , Integer> payload)
    {
        int cartId = payload.get("cart_id");
        return ResponseEntity.ok(orderService.addOrder(cartId));
    }

    @GetMapping("/get")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getOrder()
    {
        return ResponseEntity.ok(orderService.getOrder());
    }

    @PostMapping("/update")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> updateOrder(@RequestBody Map<String , String> payload)
    {
        int orderId = Integer.parseInt(payload.get("order_id"));
        String status = payload.get("status");
        return ResponseEntity.ok(orderService.updateOrder(orderId, status));
    }

    @GetMapping("/getByUser")
    public ResponseEntity<?> getOrderById(Principal principal)
    {
        String username = principal.getName();
        return ResponseEntity.ok(orderService.getOrderById(username));
    }
}
