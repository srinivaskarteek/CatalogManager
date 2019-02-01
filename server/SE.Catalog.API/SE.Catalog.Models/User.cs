﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SE.Catalog.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Roles Role { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
