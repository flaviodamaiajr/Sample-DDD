using Agenda.Dominio.Entidade;
using Agenda.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.Servico
{
    public class PessoaContatoServico
    {
        private readonly IPessoaContatoRepositorio _repositorio;

        public PessoaContatoServico(IPessoaContatoRepositorio pessoaContatoRepositorio)
        {
            this._repositorio = pessoaContatoRepositorio;
        }

        public IList<PessoaContato> RetornaTodosContatos()
        {
            return this._repositorio.RetornaTodosContatos();
        }

        public PessoaContato RetornarContatoPorPessoa(Pessoa pessoa)
        {
            return this._repositorio.RetornarContatoPorPessoa(pessoa);
        }

        public void SalvarContato(PessoaContato pessoaContato)
        {
            this._repositorio.Salva(pessoaContato);
        }
    }
}
