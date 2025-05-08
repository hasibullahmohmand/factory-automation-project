package com.project.factory.service;

import com.project.factory.model.User;
import com.project.factory.model.UserPrincipal;
import com.project.factory.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.authority.SimpleGrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MyUserDetailsService implements UserDetailsService {

    @Autowired
    private UserRepository userRepository;

    @Override
    public UserDetails loadUserByUsername(String email) throws UsernameNotFoundException
    {
        User user = userRepository.findUserByEmail(email).orElseThrow(() -> new UsernameNotFoundException("User not found: " + email));

        List<SimpleGrantedAuthority> authorities;

        if (user.getRole().startsWith("ROLE_"))
        {
            authorities = List.of(new SimpleGrantedAuthority(user.getRole()));
        }
        else
        {
            authorities = List.of(new SimpleGrantedAuthority("ROLE_" + user.getRole()));
        }

        return new UserPrincipal(user , authorities);
    }
}
