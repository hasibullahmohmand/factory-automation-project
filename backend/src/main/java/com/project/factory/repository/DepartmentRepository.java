package com.project.factory.repository;


import com.project.factory.model.Department;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.repository.CrudRepository;
import org.springframework.web.bind.annotation.RestController;

@RestController
public interface DepartmentRepository extends JpaRepository<Department, Integer>
{

    boolean existsByName(String name);
}
