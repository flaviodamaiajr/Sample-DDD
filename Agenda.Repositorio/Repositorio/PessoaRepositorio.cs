using Agenda.Dominio.Entidade;
using Agenda.Dominio.IRepositorio;
using Agenda.Repositorio.Helper;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Agenda.Repositorio.Repositorio
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public IList<Pessoa> RetornaAniversariantesDoMes()
        {
            var dataInicial = DateTime.Now.ToString("yyyy-MM-dd 00:00:00");
            var dataFinal = DateTime.Now.ToString("yyyy-MM-dd 23:59:59");

            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateQuery("from Pessoa as p where p.PsaDataNascimento >= :dataInicial and p.PsaDataNascimento <= :dataFinal")
                            .SetString("dataInicial", dataInicial)
                            .SetString("dataFinal", dataFinal)
                            .List<Pessoa>();
        }

        public IList<Pessoa> RetornarContatoPorNome(string nome)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.CreateQuery(string.Format("from Pessoa as p where p.PsaNome like '%{0}%'", nome))                            
                            .List<Pessoa>();
        }

        public Pessoa RetornaPessoaPorId(int id)
        {
            return this.RetornaPorId(id);
        }
    }
}
