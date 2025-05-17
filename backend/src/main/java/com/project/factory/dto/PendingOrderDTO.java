package com.project.factory.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@NoArgsConstructor
@AllArgsConstructor
public class PendingOrderDTO
{
    private Integer id;
    private String username;
    private boolean delivered;
    private LocalDateTime orderDate;
}