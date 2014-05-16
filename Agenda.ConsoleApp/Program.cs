
using Agenda.Dominio.Entidade;
using Agenda.Dominio.Servico;
using Agenda.Repositorio.Repositorio;
using System;

namespace Agenda.ConsoleApp
{
    /// <summary>
    /// @Program: Exemplo de consumo de serviços do Dominio
    /// @Author: Flávio da Maia Júnior
    /// @Date: 28/02/2014
    /// </summary>
    class Program
    {
        //Instanciando o serviço PessoaServico e injetando o repositório no serviço de Domínio
        protected static readonly PessoaServico _pessoaServico = new PessoaServico(new PessoaRepositorio());
        protected static readonly PessoaContatoServico _pessoaContatoServico = new PessoaContatoServico(new PessoaContatoRepositorio());


        static void Main(string[] args)
        {
            MenuPrincipal();

        }

        private static void MenuPrincipal()
        {
            try
            {
                while (true)
                {
                    Console.Clear();
                    Console.Write(":: Menu ::\n 1 - Listar\n 2 - Incluir \n 3 - Editar \n 4 - Excluir \n 5 - Sair \n\n");
                    int opcao = int.Parse(Console.ReadLine().ToString());
                    Console.Clear();
                    switch (opcao)
                    {
                        case 1:
                            ListaPessoas();
                            break;
                        case 2:
                            IncluiPessoa();
                            break;
                        case 3:
                            EditaPessoa();
                            break;
                        case 4:
                            ExcluirPessoa();
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Opção inválida!");
                            Console.ReadLine();
                            MenuPrincipal();
                            break;
                    }



                    //Console.Clear();
                    //Console.WriteLine(":: Listagem das pessoas cadastradas na agenda ::\n");
                    //Console.WriteLine(string.Format("\nTotal de pessoas cadastradas na agenda: {0}", listaPessoas.Count));
                    //Console.ReadLine();


                    //Console.Clear();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Ocorreu um erro durante a incialização! M_otivo: {0}", ex.Message));
            }
        }

        private static void ListaPessoas()
        {
            try
            {
                Console.WriteLine(":: Listagem das pessoas cadastradas na agenda ::\n");
                //Acessa o método RetornarTodasPessoas do serviço a qual retorna uma lista do tipo Pessoa
                var listaPessoas = _pessoaServico.RetornaTodasPessoas();
                //Acessa os valores da listaPessoas 
                foreach (var pessoa in listaPessoas)
                {
                    //Apresenta na tela do console o nome completo da pessoa cadastrada
                    Console.WriteLine(string.Format("Nome: {0} {1}", pessoa.PsaNome, pessoa.PsaSobreNome));
                }
                //Apresenta na tela o total de pessoas cadastradas
                Console.WriteLine(string.Format("\nTotal de pessoas cadastradas na agenda: {0}", listaPessoas.Count));
                Console.ReadLine();
                MenuPrincipal();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Ocorreu um erro durante a listagem! Motivo: {0}", ex.Message));
            }
        }

        private static void IncluiPessoa()
        {
            Console.WriteLine(":: Incluir Pessoa ::\n");
            var pessoa = new Pessoa();
            var pessoaContato = new PessoaContato();

            Console.WriteLine("Informe o nome: ");
            pessoa.PsaNome = Console.ReadLine().Trim();
            Console.WriteLine("Informe o sobrenome: ");
            pessoa.PsaSobreNome = Console.ReadLine().Trim();
            Console.WriteLine("Informe o genero (M - Masc, F -Fem): ");
            switch (Console.ReadLine().ToUpper())
            {
                case "M":
                    pessoa.PsaGenero = (char)Dominio.ObjetoDeValor.Genero.Masculino;
                    break;
                case "F":
                    pessoa.PsaGenero = (char)Dominio.ObjetoDeValor.Genero.Feminino;
                    break;
            }
            Console.WriteLine("Contato:");
            pessoaContato.PscTelefone = Console.ReadLine().Trim();
            
            var retorno = _pessoaServico.SalvaPessoa(pessoa);
            pessoaContato.Pessoa = pessoa;
            _pessoaContatoServico.SalvarContato(pessoaContato);
            Console.WriteLine(retorno);
            Console.ReadLine();
            MenuPrincipal();


            //var pessoa01 = new Pessoa() { PsaNome = "Kelly", PsaSobreNome = "Slater" };
            //var pessoa02 = new Pessoa() { PsaNome = "Adriano", PsaSobreNome = "de Souza" };
            //var pessoa03 = new Pessoa() { PsaNome = "Mick", PsaSobreNome = "Fanning" };
            //var pessoa04 = new Pessoa() { PsaNome = "Gabriel", PsaSobreNome = "Medina" };
            //var pessoa05 = new Pessoa() { PsaNome = "Alejo", PsaSobreNome = "Muniz" };

            //_pessoaServico.SalvaPessoa(pessoa01);
            //_pessoaServico.SalvaPessoa(pessoa02);
            //_pessoaServico.SalvaPessoa(pessoa03);
            //_pessoaServico.SalvaPessoa(pessoa04);
            //_pessoaServico.SalvaPessoa(pessoa05);
        }

        private static void EditaPessoa()
        {
            Console.WriteLine(":: Listagem das pessoas cadastradas na agenda ::\n");


            foreach (var p in _pessoaServico.RetornaTodasPessoas())
            {
                Console.WriteLine(string.Format("Id: {0} Nome: {1} {2}", p.PsaId, p.PsaNome, p.PsaSobreNome));

            }

            Console.WriteLine("\nQual pessoa deseja editar? \n");

            var pessoa = _pessoaServico.RetornaPessoaPorId(int.Parse(Console.ReadLine()));
            Console.WriteLine("Informe o nome: ");
            pessoa.PsaNome = Console.ReadLine().Trim();
            Console.WriteLine("Informe o sobrenome: ");
            pessoa.PsaSobreNome = Console.ReadLine().Trim();
            Console.WriteLine("Informe o genero (M - Masc, F -Fem): ");
            switch (Console.ReadLine().ToUpper())
            {
                case "M":
                    pessoa.PsaGenero = (char)Dominio.ObjetoDeValor.Genero.Masculino;
                    break;
                case "F":
                    pessoa.PsaGenero = (char)Dominio.ObjetoDeValor.Genero.Feminino;
                    break;
            }
            var retorno = _pessoaServico.SalvaPessoa(pessoa);
            Console.WriteLine(retorno);
            Console.ReadLine();
        }

        private static void ExcluirPessoa()
        {
            Console.WriteLine(":: Listagem das pessoas cadastradas na agenda ::\n");
            foreach (var p in _pessoaServico.RetornaTodasPessoas())
            {
                Console.WriteLine(string.Format("Id: {0} Nome: {1} {2}", p.PsaId, p.PsaNome, p.PsaSobreNome));

            }
            Console.WriteLine("\nQual pessoa deseja excluir? \n");
            var retorno = _pessoaServico.ExcluiPessoa(int.Parse(Console.ReadLine()));
            Console.WriteLine(retorno);
            Console.ReadLine();
        }
    }
}
