﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonelKayit.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }
    }
}