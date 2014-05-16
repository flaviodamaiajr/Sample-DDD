using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Agenda.Web.Handler
{
    /// <summary>
    /// Summary description for ExcluirContatoHandler
    /// </summary>
    public class ExcluirContatoHandler : IHttpHandler
    {
        public static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
    
            //context.Response.Write(JsonConvert.SerializeObject(retorno));
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