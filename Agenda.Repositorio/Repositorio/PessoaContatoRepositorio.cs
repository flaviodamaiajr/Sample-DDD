using Agenda.Dominio.Entidade;
using Agenda.Dominio.IRepositorio;
using Agenda.Repositorio.Helper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Repositorio.Repositorio
{
    public class PessoaContatoRepositorio : RepositorioBase<PessoaContato>, IPessoaContatoRepositorio
    {
        public IList<PessoaContato> RetornaTodosContatos()
        {
            return this.RetornaTodos02();
        }

        public IList<PessoaContato> RetornaTodos02()
        {
            return this.RetornaTodos();
        }

        public PessoaContato RetornarContatoPorPessoa(Pessoa pessoa)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateQuery("from PessoaContato as p where p.Pessoa.PsaId = :id")
                            .SetParameter("id", pessoa.PsaId)
                            .List<PessoaContato>().FirstOrDefault();
        }

    }
}
