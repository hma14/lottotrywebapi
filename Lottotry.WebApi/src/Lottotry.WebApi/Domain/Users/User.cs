namespace Lottotry.WebApi.Domain.Users;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Destructurama.Attributed;
using Lottotry.WebApi.Exceptions;
using Lottotry.WebApi.Domain.Users.Models;
using Lottotry.WebApi.Domain.Users.DomainEvents;
using Lottotry.WebApi.Domain.Emails;
using System.Collections.Generic;

public class User : BaseEntity
{
    public string Username { get; private set; }

   public Email Email { get; private set; }

    public string PasswordHash { get; private set; }

    public string Role { get; private set; }

    [NotMapped]
    public List<IDomainEvent> DomainEvents { get; set; }

    // Add Props Marker -- Deleting this comment will cause the add props utility to be incomplete


    public static User Create(UserForCreation userForCreation)
    {
        var newUser = new User();

        newUser.Username = userForCreation.Username;
        newUser.Email = Email.Of(userForCreation.Email);
        newUser.PasswordHash = userForCreation.PasswordHash;
        newUser.Role = userForCreation.Role;

        newUser.QueueDomainEvent(new UserCreated(){ User = newUser });
        
        return newUser;
    }

    public User Update(UserForUpdate userForUpdate)
    {
        Username = userForUpdate.Username;
        Email = Email.Of(userForUpdate.Email);
        PasswordHash = userForUpdate.PasswordHash;
        Role = userForUpdate.Role;

        QueueDomainEvent(new UserUpdated(){ Id = Id });
        return this;
    }

    // Add Prop Methods Marker -- Deleting this comment will cause the add props utility to be incomplete
    
    protected User() { } // For EF + Mocking
}