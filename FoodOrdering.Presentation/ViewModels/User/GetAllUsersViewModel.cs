using System;

namespace FoodOrdering.Presentation.ViewModels.User
{
    public class GetAllUsersViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
