package com.project.factory.service;


import com.project.factory.model.Category;
import com.project.factory.repository.CategoryRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class CategoryService
{
    @Autowired
    private CategoryRepository categoryRepository;

    public List<Category> getCategory()
    {
        return categoryRepository.findAll();
    }
}
