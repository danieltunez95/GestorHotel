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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            UsuarioBus usuarioBus = new UsuarioBus();
            string username = this.Username.Text;
            string password = this.Password.Text;
            UsuarioDto usuario = usuarioBus.Login(username, password);
            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                Response.Redirect("/Manage/Main.aspx");
            }
        }
    }
}