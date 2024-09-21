﻿using Domain.Common;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos.Users
{
    public class FullUserDto
    {
        public Guid Id { get;  set; }
        public string UserName { get;  set; }       
        public string? FirstName { get;  set; }
        public string? LastName { get;  set; }
        public string? Mobile { get;  set; }
        public string? Email { get;  set; }
        public string? Province { get;  set; }
        public string? City { get;  set; }
        public string? Address { get;  set; }
        public string? PostalCode { get;  set; }
       
    }
}
