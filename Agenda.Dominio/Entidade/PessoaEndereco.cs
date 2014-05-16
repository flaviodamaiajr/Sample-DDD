using Agenda.Dominio.ObjetoDeValor;
using System;

namespace Agenda.Dominio.Entidade
{
    /// <summary>
    /// @Entidade PessoaEndereco
    /// @author: Flávio Da Maia Júnior
    /// @Date: 28/02/2014
    /// </summary>
    public class PessoaEndereco
    {
        public virtual int PseId { get; set; }
        public virtual string PseEndereco { get; set; }
        public virtual string PseCep { get; set; }
        public virtual string PseCidade { get; set; }
        public virtual string PseBairro { get; set; }
        public virtual string PseEstado { get; set; }
        public virtual string PsePais { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual int PseTipoEndereco { get; set; }
    }
}
