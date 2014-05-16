using Agenda.Dominio.Entidade;
using Agenda.Dominio.ObjetoDeValor;
using FluentNHibernate.Mapping;
using System;

namespace Agenda.Repositorio.Mapeamento
{
    public class PessoaMap : ClassMap<Pessoa>
    {
        public PessoaMap()
        {
            Table("pessoa");
            Id(x => x.PsaId,"ID");
            Map(x => x.PsaNome, "NOME");
            Map(x => x.PsaSobreNome, "SOBRE_NOME");
            Map(x => x.PsaDataNascimento, "DATA_NASCIMENTO");
            Map(x => x.PsaDataCadastro, "DATA_CADASTRO");
            Map(x => x.PsaGenero, "GENERO");
            Map(x => x.PsaRelacionamento, "RELACIONAMENTO");
            HasMany<PessoaEndereco>(x => x.ListaPessoaEndereco).Table("pessoaendereco")
                                   .KeyColumn("PESSOA_ID").Not.LazyLoad()
                                   .Cascade.AllDeleteOrphan();
            HasMany<PessoaContato>(x => x.ListaPessoaContato).Table("pessoacontato")
                                   .KeyColumn("PESSOA_ID")
                                   .Not.LazyLoad()
                                   .Cascade.AllDeleteOrphan();
        }
    }
}
