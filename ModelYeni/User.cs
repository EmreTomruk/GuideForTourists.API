using System;
using System.Collections.Generic;

#nullable disable

namespace TouristGuide.API.ModelYeni
{
    public partial class User
    {
        public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Username { get; set; }
    }
}
