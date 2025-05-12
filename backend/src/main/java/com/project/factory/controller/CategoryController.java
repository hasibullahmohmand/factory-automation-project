package com.project.factory.controller;


import com.project.factory.model.Category;
import com.project.factory.service.CategoryService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/category")
public class CategoryController
{

    @Autowired
    private CategoryService categoryService;

    @GetMapping()
    public ResponseEntity<?> getCategory()
    {
        return ResponseEntity.ok(categoryService.getCategory());
    }

    @PostMapping("/add")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> addCategory(@RequestBody Category category)
    {
        Category addCategory = categoryService.addCategory(category);

        if (addCategory == null)
        {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok("Category added successfully");
    }

    @DeleteMapping("/delete/{id}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> deleteCategory(@PathVariable int id)
    {
        int category = categoryService.deleteCategory(id);

        if (category == 0)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok("Category deleted successfully");
    }

    @PostMapping("/update")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> updateCategory(@RequestBody Category category)
    {
        Category updatedCategory = categoryService.updateCategory(category);

        if (updatedCategory == null)
        {
            return ResponseEntity.badRequest().build();
        }

        return ResponseEntity.ok("Category updated successfully");
    }



}
