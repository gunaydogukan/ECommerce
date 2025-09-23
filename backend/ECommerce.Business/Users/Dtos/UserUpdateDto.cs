﻿namespace ECommerce.Business.Users.Dtos
{
    public record UserUpdateDto
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}