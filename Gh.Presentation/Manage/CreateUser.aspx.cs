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
            user.Role = int.Parse(this.role.SelectedValue);
            user.MinHour = float.Parse(this.minHour.Text.Replace(":", ","));
            user.MaxHour = float.Parse(this.maxHour.Text.Replace(":", ","));

            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.AddUser(user);
        }
    }
}