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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            UsuarioDto user = new UsuarioDto();
            user.Username = this.username.Text;
            user.Password = this.password.Text;
            user.Role = this.role.SelectedValue;
            user.MinHour = this.minHour.Text;
            user.MaxHour = this.maxHour.Text;

            UsuarioBus usuarioBus = new UsuarioBus()
            usuarioBus.AddUser(user);
        }
    }
}