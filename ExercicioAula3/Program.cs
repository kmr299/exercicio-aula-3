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
        static void Main(string[] args)
        {
            while (true)
            {

                Console.Clear();

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
                       
                        break;
                    case "2":
                        break;
                }
            }
        }
    }
}
