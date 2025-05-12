package com.project.factory.controller;


import com.project.factory.model.Department;
import com.project.factory.service.DepartmentService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController()
@RequestMapping("/department")
public class DepartmentController
{

    @Autowired
    private DepartmentService departmentService;

    @GetMapping("/get")
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<?> getDepartments()
    {

        List<Department> departments = departmentService.getDepartments();

        if (departments == null)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok(departments);
    }

    @PostMapping("/add")
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<?> addDepartment(@RequestBody Department department)
    {
        Department addedDepartment = departmentService.addDepartment(department);

        if (addedDepartment == null)
        {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok("Department added successfully");
    }

    @PostMapping("/update")
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<?> updateDepartment(@RequestBody Department department)
    {
        Department updatedDepartment = departmentService.updateDepartment(department);

        if (updatedDepartment == null)
        {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok("Department updated successfully");
    }

    @DeleteMapping("/delete/{id}")
    @PreAuthorize("hasRole('ADMIN')")
    public ResponseEntity<?> deleteDepartment(@PathVariable int id)
    {
        int department = departmentService.deleteDepartment(id);

        if(department == 0)
        {
            return ResponseEntity.notFound().build();
        }
        return ResponseEntity.ok("Department deleted successfully");
    }

}
