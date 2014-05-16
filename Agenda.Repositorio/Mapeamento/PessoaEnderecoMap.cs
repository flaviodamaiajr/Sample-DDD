using Agenda.Dominio.Entidade;
using FluentNHibernate.Mapping;

namespace Agenda.Repositorio.Mapeamento
{
    public class PessoaEnderecoMap : ClassMap<PessoaEndereco>
    {
        public PessoaEnderecoMap()
        {
            Table("pessoaendereco");
            Id(x => x.PseId, "ID");
            Map(x => x.PseEndereco, "ENDERECO");
            Map(x => x.PseTipoEndereco, "TIPO_ENDERECO").CustomType<int>();
            Map(x => x.PseCep, "CEP");
            Map(x => x.PseCidade, "CIDADE");
            Map(x => x.PseBairro, "BAIRRO");
            Map(x => x.PseEstado, "ESTADO");
            Map(x => x.PsePais, "PAIS");
        }
    }
}
