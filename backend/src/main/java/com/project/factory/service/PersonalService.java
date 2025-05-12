package com.project.factory.service;


import com.project.factory.model.Personal;
import com.project.factory.repository.PersonalRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PersonalService
{
    @Autowired
    private PersonalRepository personalRepository;

    public List<Personal> getAllPersonal()
    {
        List<Personal> personal = personalRepository.findAll();

        if (personal.isEmpty())
        {
            return null;
        }
        return personal;
    }

    public Personal addPersonal(Personal personal)
    {
        if(personalRepository.existsByIdentifier(personal.getIdentifier()))
        {
            return null;
        }

        personal.setId(null);
        return personalRepository.save(personal);
    }

    public int deletePersonal(int id)
    {
        if (personalRepository.existsById(id))
        {
            personalRepository.deleteById(id);
            return id;
        }
        return 0;
    }

    public Personal updatePersonal(Personal personal)
    {
        if (personalRepository.existsById(personal.getId()))
        {
            return personalRepository.save(personal);
        }
        return null;
    }
}
