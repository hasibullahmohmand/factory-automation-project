package com.project.factory.controller;

import com.project.factory.model.Personal;
import com.project.factory.service.PersonalService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/personal")
public class PersonalController
{
    @Autowired
    private PersonalService personalService;

    @GetMapping
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> getAllPersonal()
    {
         List<Personal> personal = personalService.getAllPersonal();

         if (personal == null)
         {
             return ResponseEntity.notFound().build();
         }

         return ResponseEntity.ok(personal);
    }

    @PostMapping("/add")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> addPersonal(@RequestBody Personal personal)
    {
        Personal addedPersonal = personalService.addPersonal(personal);

        if (addedPersonal == null)
        {
            return ResponseEntity.badRequest().build();
        }


        return ResponseEntity.ok("Personal added successfully");
    }

    @DeleteMapping("/delete/{id}")
    @PreAuthorize("hasAuthority('ADMIN')")
    public ResponseEntity<?> deletePersonal(@PathVariable int id)
    {
        int personal = personalService.deletePersonal(id);

        if (personal == 0)
        {
            return ResponseEntity.notFound().build();
        }

        return ResponseEntity.ok("Personal deleted successfully");
    }

}
