﻿using System;
using System.Text.Json.Serialization;

namespace Common.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      
    }
}
