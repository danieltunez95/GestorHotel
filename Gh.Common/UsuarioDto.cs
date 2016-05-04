using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gh.Common
{
    public class UsuarioDto
    {
        private string username;
        private string password;
        private string email;
        private int role;
        private float minHour;
        private float maxHour;

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string MinHour { get; set; }
        public string MaxHour { get; set; }
    }
}
