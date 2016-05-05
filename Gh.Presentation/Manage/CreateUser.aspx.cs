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
            this.role.DataSource = Enum.GetNames(typeof(Role));
            this.role.DataBind();
        }

        protected void createButton_Click(object sender, EventArgs e)
        {
            UsuarioDto user = new UsuarioDto();
            user.Username = this.username.Text;
            user.Password = this.password.Text;
            user.Role = (Role)Enum.Parse(typeof(Role), this.role.SelectedValue != "" ? this.role.SelectedValue : "0");
            user.MinHour = float.Parse(this.minHour.Text.Replace(":", ","));
            user.MaxHour = float.Parse(this.maxHour.Text.Replace(":", ","));

            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.AddUser(user);

            Response.Redirect("Users.aspx");
        }
    }
}