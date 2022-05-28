using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiago_Application_test
{
    internal class Program
    {
        static public Dictionary<string, string> AllUsers { get; set; } = new Dictionary<string, string>
        {
                {"usuario1@email.com","senha1"},
                {"usuario2@email.com","senha2"},
                {"usuario3@email.com","senha3"},
                {"usuario4@email.com","senha4"},
                {"usuario5@email.com","senha5"}
        };

        static void Main(string[] args)
        {
            Inicio();
        }

        static void Inicio()
        {
            Console.WriteLine("Ola,ja possui cadrastro?");
            Console.WriteLine("Caso já possua cadastro digite 1 ou digite 2 para criar seu cadastro");
            int resp = int.Parse(Console.ReadLine());

            if (resp == 1)
            {
                Login();
            }
            else if (resp == 2)
            {
                CriarCadastro();
            }
            else
            {
                Console.WriteLine("Opção invalida");
                Console.ReadKey();
                Console.Clear();
                Inicio();          
            }
        }

        static void CriarCadastro()
        {
            var allUsers = AllUsers;
            int idade = 0;
            string nome = "";
            string email = "";
            string senha = "";
            string verificacaoSenha = "";

            Console.Clear();
            Console.WriteLine("Preencha os campos abaixo para criar seu cadastro:");
            Console.WriteLine();
            Console.WriteLine("Nome Completo: ");
            nome = Console.ReadLine();

            Console.WriteLine("Idade: ");
            idade = int.Parse(Console.ReadLine());

            Console.WriteLine("Email: ");
            email = Console.ReadLine();

            Console.WriteLine("Senha: ");
            senha = Console.ReadLine();

            Console.WriteLine("Digite a senha novamente");
            verificacaoSenha = Console.ReadLine();

            
            while (verificacaoSenha != senha)
            {
                Console.Clear();
                Console.WriteLine("Senha cadastral digitada incorretamente");

                Console.WriteLine("Senha: ");
                senha = Console.ReadLine();
                
                Console.WriteLine("Digite a senha novamente");
                verificacaoSenha = Console.ReadLine();

            }

            var userExists = allUsers.Where(user => user.Key == email).FirstOrDefault();

                if (userExists.Key is null)
                {
                    AllUsers.Add(email, senha);
                    Console.WriteLine("Usuario adicionado com sucesso!");
                    Login();
                }
                else
                {
                    Console.WriteLine("Usuario já existe");
                    Inicio();
                }

        }

        static void Login()
        {
            int numeroMaximoTentativas = 3;
            string userLogin = "";
            string passwordLogin = "";
            var allUsers = AllUsers;

            for (int i = 0; i < numeroMaximoTentativas; i++)
            {
                if (i == 0)
                {
                    Console.Clear();
                }
                Console.Clear();
                Console.WriteLine("Digite Usuario e senha para entrar:");

                Console.WriteLine("Usuario: ");
                userLogin = Console.ReadLine();

                Console.WriteLine("Senha:");
                passwordLogin = Console.ReadLine();

                //CAPRICHO, pesquisar como deixar a senha com * no console;

                var userExists = allUsers.Where(user => user.Key == userLogin && user.Value == passwordLogin).FirstOrDefault();

                if (userExists.Key is not null)
                {
                    Menu();
                }
                else
                {

                    if (i < 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuario ou senha invalidos, por favor digite novamente");                      
                        continue;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Tentativas excedidas, usuario bloqueado");
                        Console.WriteLine("Contate o suporte");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Bem vindo!");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Exibir seu cadastro");
            Console.WriteLine("2 - Alterar seu cadastro");
            Console.WriteLine("3 - Sair");
            int r = int.Parse(Console.ReadLine());
            if( r == 3 )
            {
                Console.Clear();
                Console.WriteLine("Volte sempre!");
                System.Environment.Exit(0);
            }
            else
            {
                Console.ReadKey();
                System.Environment.Exit(0);
            }     
        }
    }
}


