using Agenda.Dominio.ObjetoDeValor;
using System;

namespace Agenda.Dominio.Entidade
{
    /// <summary>
    /// @Entidade PessoContato
    /// @author: Flávio Da Maia Júnior
    /// @Date: 28/02/2014
    /// </summary>
    public class PessoaContato
    {
        public virtual int PscId { get; set; }
        public virtual string PscTelefone { get; set; }
        public virtual int PscTipoTelefone { get; set; }
        public virtual string PscEmail { get; set; }
        public virtual int PscTipoEmail2 { get; set; }
        
        public virtual int PscTipoEmail { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
