using ExercicioAula3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula3
{
    class Program
    {
        static string tokenUsuario { get; set; }

        static void Main(string[] args)
        {
            while (true)
            {



                Console.Clear();

                if (string.IsNullOrWhiteSpace(tokenUsuario))
                {
                    /////////////////////////////////////////////////////////////////////
                    //Cadastrar Usuario
                    Log.PrintELog("1 - Cadastrar Usuario");
                    /*
                     * |    Dados do usuário
                     * ------------------------------------------------------------------
                     * |    Digite um nome:
                     * |    Digite um email:
                     * |    Digite uma senha:
                     * |-----------------------------------------------------------------
                     * |    Usuário cadastrado com sucesso!
                     */
                    /////////////////////////////////////////////////////////////////////

                    /////////////////////////////////////////////////////////////////////
                    //Cadastrar Usuario
                    Log.PrintELog("2 - Login");
                    /*
                     * |    Dados do login
                     * ------------------------------------------------------------------
                     * |    Digite um email:
                     * |    Digite uma senha:
                     * |-----------------------------------------------------------------
                     * |    Usuário Logado Com sucesso
                     * |-----------------------------------------------------------------
                     * |    Suas listas de tarefas (x)
                     * |-----------------------------------------------------------------
                     * |    ID      |   Nome
                     * |-----------------------------------------------------------------
                     * |    1       |   Lista Um
                     * |    2       |   Lista Dois
                     * |-----------------------------------------------------------------
                     * |    Opções:
                     * |    1 - Cadastrar Lista
                     * |    2 - Cadastrar Nova Tarefa
                     * |    3 - Listar Tarefas
                     * |    4 - Alterar Tarefas
                     * |    5 - Remover Tarefas
                     * |    6 - Concluir Tarefas
                     * |    7 - Não Concluir Tarefas
                     */
                    /////////////////////////////////////////////////////////////////////

                    switch (Console.ReadLine())
                    {
                        case "1":
                            CadastrarUsuario();
                            break;
                        case "2":
                            tokenUsuario = Login();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Usuário Logado");

                    var taskListasDeTarefas = Api.Api.BuscarListaUsuario(tokenUsuario);
                    taskListasDeTarefas.Wait();
                    var listasDeTarefas = taskListasDeTarefas.Result;

                    Console.WriteLine("| -----------------------------------------------------------------");
                    Console.WriteLine($"| Suas listas de tarefas ({listasDeTarefas.Count()})");
                    Console.WriteLine("| -----------------------------------------------------------------");
                    Console.WriteLine("|    ID      |   Nome");
                    Console.WriteLine("|-----------------------------------------------------------------");

                    foreach (var lista in listasDeTarefas)
                        Console.WriteLine($"|  {lista.ListaId}      |    {lista.Nome}");

                    Console.WriteLine("|-----------------------------------------------------------------");
                    Console.WriteLine("|    Opções:");
                    Console.WriteLine("|    1 - Cadastrar Lista");
                    Console.WriteLine("|    2 - Cadastrar Nova Tarefa");
                    Console.WriteLine("|    3 - Listar Tarefas");
                    Console.WriteLine("|    4 - Alterar Tarefas");
                    Console.WriteLine("|    5 - Remover Tarefas");
                    Console.WriteLine("|    6 - Concluir Tarefas");
                    Console.WriteLine("|    7 - Não Concluir Tarefas");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            break;
                        case "2":
                            break;
                        case "3":
                            break;
                        case "4":
                            break;
                        case "5":
                            break;
                        case "6":
                            break;
                        case "7":
                            break;
                    }
                }
            }
        }

        private static string Login()
        {
            Console.WriteLine("Login");
            Console.WriteLine("Digite um Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Digite uma Senha:");
            var senha = Console.ReadLine();
            var task = Api.Api.LoginUsuario(email, senha);
            task.Wait();
            return task.Result;
        }

        private static void CadastrarUsuario()
        {
            Console.WriteLine("Cadastrar usuários");
            Console.WriteLine("Digite um Nome:");
            var nome = Console.ReadLine();
            Console.WriteLine("Digite um Email:");
            var email = Console.ReadLine();
            Console.WriteLine("Digite uma Senha:");
            var senha = Console.ReadLine();

            Api.Api.RegistrarUsuario(nome, email, senha).Wait();
        }
    }
}