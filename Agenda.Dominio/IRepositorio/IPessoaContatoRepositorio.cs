using Agenda.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Dominio.IRepositorio
{
    public interface IPessoaContatoRepositorio : IRepositorioBase<PessoaContato>
    {
        IList<PessoaContato> RetornaTodosContatos();
        PessoaContato RetornarContatoPorPessoa(Pessoa pessoa);

    }
}
