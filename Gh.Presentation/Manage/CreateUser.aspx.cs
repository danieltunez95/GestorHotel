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
            if (!IsPostBack)
            {
                this.role.DataSource = Enum.GetNames(typeof(Role));
                this.role.DataBind();

                if (Request.QueryString["userId"] != null)
                {
                    UsuarioBus usuarioBus = new UsuarioBus();
                    UsuarioDto usuario = usuarioBus.GetUser(int.Parse(Request.QueryString["userId"]));

                    this.username.Text = usuario.Username;
                    this.username.Enabled = false; //Dont want it to be editable
                                                   //this.password.Text = usuario.Password; //if wanted to display the current password
                    this.role.SelectedIndex = (int)usuario.Role;
                    this.minHour.Text = usuario.MinHour.ToString();
                    this.maxHour.Text = usuario.MaxHour.ToString();

                    this.createButton.Visible = false;
                    this.deleteButton.Visible = true;
                    this.updateButton.Visible = true;
                }
                else
                {
                    this.createButton.Visible = true;
                    this.deleteButton.Visible = false;
                    this.updateButton.Visible = false;
                }
            }
        }
        private UsuarioDto GetActualUser()
        {
            UsuarioDto usuario = new UsuarioDto();
            usuario.Username = this.username.Text;
            usuario.Password = this.password.Text;
            usuario.Role = (Role)Enum.Parse(typeof(Role), this.role.SelectedValue != "" ? this.role.SelectedValue : "0");
            usuario.MinHour = float.Parse(this.minHour.Text.Replace(":", ","));
            usuario.MaxHour = float.Parse(this.maxHour.Text.Replace(":", ","));

            if (Request.QueryString["userId"] != null)
                usuario.Id = int.Parse(Request.QueryString["userId"]);

                return usuario;
        }
        protected void createButton_Click(object sender, EventArgs e)
        {
            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.AddUser(GetActualUser());

            Response.Redirect("Users.aspx");
        }

        protected void updateButton_Click(object sender, EventArgs e)
        {
            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.UpdateUser(GetActualUser());

            Response.Redirect("Users.aspx");
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {
            UsuarioBus usuarioBus = new UsuarioBus();
            usuarioBus.DeleteUser(GetActualUser());

            Response.Redirect("Users.aspx");
        }
    }
}