﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Icon { get; set; }

    }

    // Todo :Composite Design Pattern For Nested Category
}
