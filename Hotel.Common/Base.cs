﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorHotel.Common
{
    public class Base
    {
        private Guid guid;
        private int id;

        public Guid Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}