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
        public int Role { get; set; }
        public float MinHour { get; set; }
        public float MaxHour { get; set; }

        /* DATABASE */
        public static string DBName
        {
            get
            {
                return "Usuario";
            }
        }
    }
}
