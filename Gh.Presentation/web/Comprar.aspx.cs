﻿using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.web
{
    public partial class Comprar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void finalizarButton_Click(object sender, EventArgs e)
        {
            ClienteDto cliente = new ClienteDto();
            cliente.Correo = this.emailBox.Text;
            cliente.Password = this.contraseñaBox.Text;
            
        }
    }
}