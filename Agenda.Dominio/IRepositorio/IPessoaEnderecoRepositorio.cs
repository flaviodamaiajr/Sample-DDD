using Agenda.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.IRepositorio
{
    public interface IPessoaEnderecoRepositorio : IRepositorioBase<PessoaEndereco>
    {
        IList<PessoaEndereco> RetornaEnderecoPorPessoaId(int id);
        PessoaEndereco RetornaEnderecoPorId(int id);
    }
}