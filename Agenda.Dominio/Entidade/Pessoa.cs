using Agenda.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;

namespace Agenda.Dominio.Entidade
{
    /// <summary>
    /// @Entidade Pessoa
    /// @author: Flávio Da Maia Júnior
    /// @Date: 28/02/2014
    /// </summary>
    public class Pessoa
    {
        public virtual int PsaId { get; set; }
        public virtual string PsaNome { get; set; }
        public virtual string PsaSobreNome { get; set; }
        public virtual DateTime PsaDataNascimento { get; set; }
        public virtual DateTime PsaDataCadastro { get; set; }
        public virtual char PsaGenero { get; set; }
        public virtual int PsaRelacionamento { get; set; }
        public virtual IList<PessoaContato> ListaPessoaContato { get; set; }
        public virtual IList<PessoaEndereco> ListaPessoaEndereco { get; set; }

        public Pessoa()
        {
            //Seta a data e hora do cadastro quando a classe for estanciada.
            this.PsaDataCadastro = DateTime.Now;
            //Inicializa as listas PessoaContato e PessoaEndereco.
            this.ListaPessoaContato = new List<PessoaContato>();
            this.ListaPessoaEndereco = new List<PessoaEndereco>();
        }
    }
}
