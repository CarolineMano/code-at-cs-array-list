
using System;

namespace ExercicioArrayLists
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcao = 0;
            string nome;
            string senha;
            var gerenciador = new GerenciadorUsuario();

            do
            {
                Console.WriteLine($"Por favor selecione uma opção: ");
                Console.WriteLine($"1 - Cadastrar Usuário ");
                Console.WriteLine($"2 - Validar Usuário ");
                Console.WriteLine($"3 - Sair ");

                int.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        Console.Write($"{Environment.NewLine}Digite um nome: ");
                        nome = Console.ReadLine();
                        Console.Write($"{Environment.NewLine}Digite uma senha: ");
                        senha = Console.ReadLine();
                        var cadastroSucesso = gerenciador.CadastrarUsuario(nome, senha);

                        if (!cadastroSucesso)
                            Console.WriteLine("A senha não foi validada com sucesso.");
                        break;

                    case 2:
                        Console.Write($"{Environment.NewLine}Digite um nome: ");
                        nome = Console.ReadLine();
                        Console.Write($"{Environment.NewLine}Digite uma senha: ");
                        senha = Console.ReadLine();
                        var resultadoValidacao = gerenciador.ValidarUsuario(nome, senha);

                        if (resultadoValidacao == CodigoValidacaoUsuario.UsuarioValidado)
                            Console.WriteLine("Usuário validado com sucesso");

                        else if (resultadoValidacao == CodigoValidacaoUsuario.UsuarioInexistente)
                            Console.WriteLine("Usuário informado não existe");

                        else if (resultadoValidacao == CodigoValidacaoUsuario.SenhaInvalida)
                            Console.WriteLine("Senha informada inválida");

                        else
                            Console.WriteLine("Senha informada inválida pela terceira vez. Usuário bloqueado");

                        break;
                    case 3:
                        Console.WriteLine("Até a próxima!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }

            } while (opcao != 3);
        }
    }
}
