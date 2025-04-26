namespace Lottotry.WebApi.Domain.Users;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using Lottotry.WebApi.Exceptions;
using Lottotry.WebApi.Domain.Users.Models;
using Lottotry.WebApi.Domain.Users.DomainEvents;
using Lottotry.WebApi.Domain.Emails;
using System.Collections.Generic;
using System;

public class User 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public string Username { get;  set; }

    [Required]
    //[EmailAddress]
    public string Email { get;  set; }

    [Required]
    public string PasswordHash { get;  set; }

    public string Role { get; set; }

    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }


    public string ConfirmationToken { get; set; }
    public bool IsConfirmed { get; set; }


    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static User Create(UserForCreation userForCreation)
    {
        var newUser = new User();

        newUser.Username = userForCreation.Username;
        newUser.Email = userForCreation.Email;
        newUser.PasswordHash = userForCreation.PasswordHash;
        newUser.Role = userForCreation.Role;

        //newUser.QueueDomainEvent(new UserCreated(){ User = newUser });
        
        return newUser;
    }

    public User Update(UserForUpdate userForUpdate)
    {
        Username = userForUpdate.Username;
        Email = userForUpdate.Email;
        PasswordHash = userForUpdate.PasswordHash;
        Role = userForUpdate.Role;

        //QueueDomainEvent(new UserUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected User() { } // For EF + Mocking
}