package com.project.factory.controller;


import com.project.factory.service.OrderService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.time.LocalDateTime;
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
        LocalDateTime deliveryDate;
        int orderId = Integer.parseInt(payload.get("order_id"));
        String status = payload.get("status");
        String deliveryDateStr = payload.get("delivery_date");


        if (deliveryDateStr == null || deliveryDateStr.isEmpty())
        {
            deliveryDate = LocalDateTime.now();
        }
        else
        {
            deliveryDate = LocalDateTime.parse(deliveryDateStr);
        }

        return ResponseEntity.ok(orderService.updateOrder(orderId, status , deliveryDate));
    }

    @GetMapping("/getByUser")
    public ResponseEntity<?> getOrderById(Principal principal)
    {
        String username = principal.getName();
        return ResponseEntity.ok(orderService.getOrderById(username));
    }

    @GetMapping("/getPendingOrders")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getPendingOrders()
    {
        if(orderService.getPendingOrders().isEmpty())
        {
            return ResponseEntity.ok("No pending orders found");
        }

        return ResponseEntity.ok(orderService.getPendingOrders());
    }

    @GetMapping("/getTopProducts")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getTopOrderedProducts()
    {
        if(orderService.getTopOrderedProducts().isEmpty())
        {
            return ResponseEntity.ok("No orders found");
        }
        return ResponseEntity.ok(orderService.getTopOrderedProducts());
    }

    @GetMapping("/revenue/delivered")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getDeliveredRevenue()
    {
        Double revenue = orderService.getDeliveredOrdersRevenue();

        if(revenue == null)
        {
            return ResponseEntity.ok("No delivered orders found");
        }

        Map<String , Double> response = Map.of("revenue", revenue);

        return ResponseEntity.ok(response);
    }
}
