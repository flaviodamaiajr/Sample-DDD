using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string Auth(string usuario, string senha)
        {
            if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha))
            {
                return "/ExemploConsulta.aspx";
            }
            return "/Login.aspx";
        }
    }
}