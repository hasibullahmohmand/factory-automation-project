package com.project.factory.repository;


import com.project.factory.model.User;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.Optional;

@Repository
public interface UserRepository extends JpaRepository<User, Integer>
{

    Optional<User> findUserByEmail(String email);

    User getUserByEmail(String email);

    @Query("SELECT u.id FROM User u WHERE u.email = :email")
    int findUserIdByEmail(@Param("email") String email);
}
