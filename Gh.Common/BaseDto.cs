using System;

namespace Gh.Common
{
    public class BaseDto
    {
        private Guid guid = Guid.Empty;
        private int id;
        private string nombre;

        public Guid Guid
        {
            get
            {
                if (guid == Guid.Empty)
                    guid = Guid.NewGuid();
                return guid;
            }
            set { guid = value; }
        }

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
