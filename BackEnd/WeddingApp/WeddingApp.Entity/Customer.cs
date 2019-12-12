﻿using System.Collections.Generic;

namespace WeddingApp.Entity
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Order> AllOrders { get; set; }
    }
}