package com.project.factory.repository;

import com.project.factory.model.Personal;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PersonalRepository extends JpaRepository<Personal, Integer>
{
    boolean existsByIdentifier(String identifier);
}
