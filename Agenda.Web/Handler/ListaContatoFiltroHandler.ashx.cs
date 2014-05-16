using Agenda.Dominio.Entidade;
using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using App.Utilities.Web.Handlers;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Agenda.Web.Handler
{
    /// <summary>
    /// Summary description for ListaContatoFiltroHandler
    /// </summary>
    public class ListaContatoFiltroHandler : BaseHandler
    {
        public static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());        

        public object FiltroPessoaNome(string nome)
        {
            var pessoa = _pessoaServico.RetornaPessoasPorNome(nome);
            if (pessoa != null)
            {
                return JsonConvert.SerializeObject(pessoa);            
            }
            return JsonConvert.SerializeObject(_pessoaServico.RetornaTodasPessoas());
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