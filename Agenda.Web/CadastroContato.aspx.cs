using Agenda.Dominio.Entidade;
using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Agenda.Dominio.ObjetoDeValor;

namespace Agenda.Web
{
    public partial class CadastroContato : System.Web.UI.Page
    {
        public static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());
        public static readonly PessoaContatoServico _pessoaContatoServico = new PessoaContatoServico(new PessoaContatoRepositorio());


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        public static object SetarContato()
        {
            if (HttpContext.Current.Session["contatoId"] != null)
            {
                var contato = _pessoaServico.RetornaPessoaPorId(int.Parse(HttpContext.Current.Session["contatoId"].ToString()));

                var json = JsonConvert.SerializeObject(contato, Formatting.Indented,
                                                          new JsonSerializerSettings()
                                                          {
                                                              ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                          });
                return json;
            }
            return new Pessoa();
        }

        [WebMethod]
        public static void SalvarContato(int id, string nome, string sobreNome, string dataAniversario, string contato)
        {
            try
            {
                var pessoa = (id.Equals(0)) ? new Pessoa() : _pessoaServico.RetornaPessoaPorId(id);
                pessoa.PsaNome = nome;
                pessoa.PsaSobreNome = sobreNome;
                pessoa.PsaDataCadastro = DateTime.Parse(dataAniversario);

                var _contato = (id.Equals(0)) ? new PessoaContato() : _pessoaContatoServico.RetornarContatoPorPessoa(pessoa);
                _contato.Pessoa = pessoa;
                _contato.PscTelefone = contato;


                _pessoaServico.SalvaPessoa(pessoa);
                _pessoaContatoServico.SalvarContato(_contato);
            }
            catch (Exception ex)
            {
                //TODO
            }
        }

        [WebMethod]
        public static string ExcluirContato(int id)
        {
            var retorno = _pessoaServico.ExcluiPessoa(id);

            return retorno;
        }

        [WebMethod(EnableSession = true)]
        public static void LimparContato()
        {
            HttpContext.Current.Session.Remove("contatoId");
        }
    }
}