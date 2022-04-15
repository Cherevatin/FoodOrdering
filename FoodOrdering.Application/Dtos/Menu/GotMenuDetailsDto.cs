﻿using System;

namespace FoodOrdering.Application.Dtos.Menu
{
    public class GotMenuDetailsDto
    {
        public Guid Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool ReadyToOrder { get; set; }

    }
}
