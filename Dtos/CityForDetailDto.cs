﻿using System.Collections.Generic;
using TouristGuide.API.Models;

namespace TouristGuide.API.Dtos
{
    public class CityForDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public List<Photo> Photos { get; set; }
    }
}
