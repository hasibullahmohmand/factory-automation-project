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

    public Category addCategory(Category category)
    {
        if(categoryRepository.existsByName(category.getName()))
        {
            return null;
        }

        category.setId(null);
        return categoryRepository.save(category);
    }

    public int deleteCategory(int id)
    {
        if (categoryRepository.existsById(id))
        {
            categoryRepository.deleteById(id);
            return id;
        }
        return 0;
    }

    public Category updateCategory(Category category)
    {
        if (categoryRepository.existsById(category.getId()))
        {
            return categoryRepository.save(category);
        }
        return null;
    }
}
