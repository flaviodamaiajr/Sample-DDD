using Agenda.Dominio.Entidade;
using Agenda.Dominio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.Dominio.Servico
{
    public class PessoaServico
    {
        // Repositório para persistir/recuperar as informações no banco de dados
        private readonly IPessoaRepositorio _repositorio;

        // Construtor que recebe o Repositório
        public PessoaServico(IPessoaRepositorio pessoaRepositorio)
        {
            // Recebe o Repositório por injeção de dependência, 
            // evitando o acoplamento entre o Dominio e a camada de Persistência
            this._repositorio = pessoaRepositorio;
        }

        public IList<Pessoa> RetornaTodasPessoas()
        {
            try
            {
                return this._repositorio.RetornaTodos();
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Ocorreu um erro durante a listagem de pessoas", "Pessoa", ex);
                throw argEx;
            }
        }

        public IList<Pessoa> RetornaPessoasPorNome(string nome)
        {
            try
            {
                return this._repositorio.RetornarContatoPorNome(nome);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Ocorreu um erro durante a listagem de pessoas", "Pessoa", ex);
                throw argEx;
            }
        }

        public Pessoa RetornaPessoaPorId(int id)
        {
            try
            {
                return this._repositorio.RetornaPorId(id);
            }
            catch (Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Ocorreu um erro durante a consulta da pessoa", "id", ex);
                throw argEx;
            }
        }

        public string SalvaPessoa(Pessoa pessoa)
        {
            try
            {
                if (pessoa.PsaId.Equals(0))
                {
                    this._repositorio.Salva(pessoa);
                    return "Contato salvo com sucesso!";
                }
                this._repositorio.Salva(pessoa);
                return "Contato atualizado com sucesso!";
            }
            catch (Exception ex)
            {
                return string.Format("Ocorreu um erro durante a transação do contato! Motivo: {0}", ex.Message);
            }
        }

        public string ExcluiPessoa(int id)
        {
            try
            {
                var pessoa = this._repositorio.RetornaPorId(id);
                if (pessoa != null)
                {
                    this._repositorio.Exclui(pessoa);
                    return "Contato excluído com sucesso!";
                }
                return "Contato inexistente ou já excluído!";
            }
            catch (Exception ex)
            {
                return string.Format("Ocorreu um erro durante a exclusão do contato! Motivo: {0}", ex.Message);
            }
        }

    }
}
