package com.project.factory.controller;


import com.project.factory.model.Cart;
import com.project.factory.repository.CartRepository;
import com.project.factory.service.CartService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.security.Principal;
import java.util.List;

@RestController
@RequestMapping("/cart")
public class CartController
{
    @Autowired
    private CartService cartService;

    @GetMapping("/add")
    public ResponseEntity<?> addCart(@RequestParam int productId, @RequestParam int quantity , Principal principal)
    {
        String username = principal.getName();
        int addCart = cartService.addCart(productId , quantity , username);
        return ResponseEntity.ok(addCart);
    }

    @GetMapping()
    public ResponseEntity<?> getAllCart(@RequestParam int userId)
    {
        return ResponseEntity.ok(cartService.getAllCartsByUserId(userId));
    }

    @GetMapping("/update")
    public ResponseEntity<?> updateCart(@RequestParam int cartId, @RequestParam int quantity , Principal principal)
    {
        String username = principal.getName();
        int updateCart = cartService.updateCart(cartId , quantity , username);
        return ResponseEntity.ok(updateCart);
    }

    @DeleteMapping("/delete")
    public ResponseEntity<?> deleteCart(@RequestParam int cartId)
    {
        cartService.deleteCart(cartId);
        return ResponseEntity.ok("Cart deleted successfully");
    }


}
