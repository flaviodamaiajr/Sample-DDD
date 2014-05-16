using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using Newtonsoft.Json;
using System.Web;

namespace Agenda.Web.Handler
{
    /// <summary>
    /// Summary description for ListaContatos
    /// </summary>
    public class ListaContatosHandler : IHttpHandler
    {
        public static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());
        public static readonly PessoaContatoServico _pessoaContatoServico = new PessoaContatoServico(new PessoaContatoRepositorio());

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            var contatos = _pessoaServico.RetornaTodasPessoas();
            var json = JsonConvert.SerializeObject(contatos, Formatting.Indented,
                                                            new JsonSerializerSettings()
                                                            {
                                                                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                            });
            context.Response.Write(json);
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