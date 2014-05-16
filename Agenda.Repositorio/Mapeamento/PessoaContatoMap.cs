using Agenda.Dominio.Entidade;
using FluentNHibernate.Mapping;
using System;

namespace Agenda.Repositorio.Mapeamento
{
    public class PessoaContatoMap : ClassMap<PessoaContato>
    {
        public PessoaContatoMap()
        {
            Table("pessoacontato");
            Id(x => x.PscId, "ID");
            Map(x => x.PscTelefone, "TELEFONE");
            Map(x => x.PscTipoTelefone, "TIPO_TELEFONE");
            Map(x => x.PscEmail, "EMAIL");
            Map(x => x.PscTipoEmail, "TIPO_EMAIL");
            Map(x => x.PscTipoEmail2);
            References(x => x.Pessoa, "PESSOA_ID");            
            
        }
    }
}
