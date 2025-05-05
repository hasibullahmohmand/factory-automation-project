package com.project.factory.service;


import com.project.factory.model.User;
import com.project.factory.repository.UserRepository;
import com.project.factory.util.JwtUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class UserService
{
    @Autowired
    private UserRepository userRepository;

    @Autowired
    private BCryptPasswordEncoder encoder;

    @Autowired
    private AuthenticationManager authentication;

    @Autowired
    private JwtUtil jwtUtil;


    public String registerUser(User user)
    {
        if(userRepository.findUserByEmail(user.getEmail()).isPresent())
        {
            return null;
        }
        user.setRole("USER");
        user.setPassword(encoder.encode(user.getPassword()));
        userRepository.save(user);
        return "User registered successfully";
    }

    public String verify(User user)
    {
        Authentication auth = authentication.authenticate(new UsernamePasswordAuthenticationToken(user.getEmail(), user.getPassword()));

        if(auth.isAuthenticated())
        {
            User newUser = userRepository.findUserByEmail(user.getEmail()).orElseThrow(() -> new RuntimeException("User not found"));
            return jwtUtil.generateToken(newUser.getEmail() , newUser.getRole());
        }

        return "fail";

    }
}
