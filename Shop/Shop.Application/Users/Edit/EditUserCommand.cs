﻿using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Shop.Domain.UserAgg.Enums;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public EditUserCommand(long userId,
                               string name,
                               IFormFile? avatar,
                               string family,
                               string phoneNumber,
                               string email,
                               Gender gender)
        {

            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
            UserId = userId;
            Avatar = avatar;
        }

        public long UserId { get; private set; }
        public IFormFile? Avatar { get; set; }
        public string Name { get; private set; }
        public string Family { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public Gender Gender { get; private set; }
    }

}
