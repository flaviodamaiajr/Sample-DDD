using Agenda.Dominio.Entidade;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.IRepositorio
{
    public interface IPessoaRepositorio : IRepositorioBase<Pessoa>
    {
        IList<Pessoa> RetornaAniversariantesDoMes();
        IList<Pessoa> RetornarContatoPorNome(string nome);        
        Pessoa RetornaPessoaPorId(int id);
    }
}