package com.project.factory.service;

import com.project.factory.model.Department;
import com.project.factory.repository.DepartmentRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DepartmentService
{
    @Autowired
    private DepartmentRepository departmentRepository;

    public List<Department> getDepartments()
    {
        return departmentRepository.findAll();
    }

    public Department addDepartment(Department department)
    {
        if(departmentRepository.existsByName(department.getName()))
        {
            return null;
        }

        department.setId(null);

        return departmentRepository.save(department);
    }


    public Department updateDepartment(Department department)
    {
        if (departmentRepository.existsById(department.getId()))
        {
            return departmentRepository.save(department);
        }
        return null;
    }

    public int deleteDepartment(int id)
    {
        if (departmentRepository.existsById(id))
        {
            departmentRepository.deleteById(id);
            return 1;
        }
        return 0;
    }
}
