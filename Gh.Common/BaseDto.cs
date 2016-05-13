using System;

namespace Gh.Common
{
    public class BaseDto
    {
        private int id;
        private string nombre;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre { get; set; }

        public BaseDto()
        {
            this.Id = -1;
        }

        
    }
}
