package com.project.factory.controller;

import com.project.factory.model.User;
import com.project.factory.service.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import java.util.Map;

@RestController
public class UserController
{

    @Autowired
    private UserService userService;

    @PostMapping("/login")
    public ResponseEntity<?> login(@RequestBody User user)
    {
        String result = userService.verify(user);

        if (result.equals("fail"))
        {
            return ResponseEntity.status(401).body("Invalid username or password");
        }

        Map<String , String> response = Map.of("token", result);

        return ResponseEntity.ok().body(response);

    }

    @PostMapping("/register")
    public ResponseEntity<?> register(@RequestBody User user)
    {
        String newUser = userService.registerUser(user);
        if (newUser != null)
        {
            return ResponseEntity.ok().body("User registered successfully");
        }
        return ResponseEntity.badRequest().body("User already exists");
    }
}
