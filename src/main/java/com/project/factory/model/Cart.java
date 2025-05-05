package com.project.factory.model;


import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Cart
{
    @Id
    @GeneratedValue(strategy = jakarta.persistence.GenerationType.IDENTITY)
    private Integer id;

    private Integer quantity;

    private LocalDateTime createdAt;

    @ManyToOne
    private Product product;

    @ManyToOne
    private User user;

    private boolean active = true;

    @PrePersist
    protected void onCreate()
    {
        createdAt = LocalDateTime.now();
    }

}
