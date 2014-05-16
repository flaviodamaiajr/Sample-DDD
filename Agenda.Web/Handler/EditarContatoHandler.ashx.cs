using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Agenda.Web.Handler
{
    /// <summary>
    /// Summary description for EditarContatoHandler
    /// </summary>
    public class EditarContatoHandler : IHttpHandler, IReadOnlySessionState
    {
        public static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());
        public static readonly PessoaContatoServico _pessoaContatoServico = new PessoaContatoServico(new PessoaContatoRepositorio());

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            if (HttpContext.Current.Session["contatoId"] != null)
            {
                var pessoa = _pessoaServico.RetornaPessoaPorId(int.Parse(HttpContext.Current.Session["contatoId"].ToString()));
                var json = JsonConvert.SerializeObject(pessoa, Formatting.Indented,
                                                             new JsonSerializerSettings()
                                                             {
                                                                 ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                             });
                context.Response.Write(json);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}