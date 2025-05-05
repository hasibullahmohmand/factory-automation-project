package com.project.factory.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Personal
{
    @Id
    @GeneratedValue(strategy = jakarta.persistence.GenerationType.IDENTITY)
    private Integer id;

    private String name;

    private String Identifier;

    private String age;

    private String gender;

    private LocalDate date;

    private String shift;

    @ManyToOne
    private Department department;

}
