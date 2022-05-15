using System;

namespace FoodOrdering.Application.Dtos.User
{
    public class GetUserDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
