using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agenda.Web
{
    public partial class ExemploConsulta : System.Web.UI.Page
    {
        protected static readonly PessoaContatoServico _pessoaContatoServico = new PessoaContatoServico(new PessoaContatoRepositorio());
        protected static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession=true)]
        public static void EditarContato(int id)
        {
            HttpContext.Current.Session["contatoId"] = id;
        }

        [WebMethod]
        public static void ExcluirContato(int id)
        {
            _pessoaServico.ExcluiPessoa(id);
        }
    }
}