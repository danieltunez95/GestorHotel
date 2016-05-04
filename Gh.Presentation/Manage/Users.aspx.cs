using Gh.Bus;
using Gh.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Gh.Presentation.Manage
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioBus usuarioBus = new UsuarioBus();
            List<UsuarioDto> usuarios = usuarioBus.GetUsers();

            this.usersView.DataSource = usuarios;
            this.usersView.DataBind();
        }

        protected void createUserButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }
    }
}