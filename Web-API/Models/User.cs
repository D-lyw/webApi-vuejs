﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_API.Models
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}