using System;
using System.Collections.Generic;

#nullable disable

namespace TouristGuide.API.ModelYeni
{
    public partial class City
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
