using System;
using System.Collections;

namespace Banco {

    internal class Administrador : Pessoa {
        private int _login;

        public int Login {
            get { return _login; }
            set { _login = value; }
        }
        public override void Menu() {
            int opcao;

            do {
                Console.Clear();

                Console.WriteLine($"Bem vindo administrador {Nome} \n");

                Console.WriteLine("O que deseja fazer?\n1 - Adicionar cliente\n2 - Remover cliente\n3 - Listar clientes\n4 - Sair\n");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao) {
                    case 1: addCliente(); break;
                    case 2: removerCliente();break;
                    case 3: listarClientes();break;
                    case 4: Console.Clear(); Console.WriteLine("Saindo...");Console.ReadLine(); break;
                    default:Console.WriteLine("Opção invalida\n\nPressione qualquer tecla para tentar novamente!");Console.ReadLine() ;break;
                }
            } while (opcao != 4);
        }
        

        private void addCliente() {
            string nome;
            string senha;
            double saldoEntrada;
            int numeroConta;
            bool gerarConta = false;

            Console.Clear();

            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            
            Console.WriteLine("\nPeça para o cliente criar a senha\nRequisitos: Minimo de 3 digitos");

            do {
                senha = Console.ReadLine();
                if (senha.Length > 2) {
                    break;
                } else {
                    Console.WriteLine("\nTente novamente!");
                }
            } while (true);

            Console.WriteLine("\nQual será saldo inicial?");
            saldoEntrada = double.Parse(Console.ReadLine());

            do {
                Random random = new Random();
                numeroConta = random.Next(10000, 99999);
                foreach (int conta in Banco.listaConta) {
                    if (numeroConta == conta) {
                        gerarConta = true;
                        break;
                    }
                    gerarConta = false;
                }
            } while (gerarConta);

            Banco.listaConta.Add(numeroConta);


            Usuario user = new Usuario(nome, numeroConta, senha, saldoEntrada);

            Console.WriteLine($"\nNome: {user.Nome}\nNumero da conta: {user.NumeroConta}\nSaldo: R${user.Saldo:F2}\n\nPressione qualquer tecla para sair!");
            Console.ReadLine();

            Banco.listaUsuario.Add(user);
        }
        private void removerCliente() {
            int nContaRemover;
            string confirmacao;
            string senhaConfirmacao;

            Console.Clear();
            try {
                Console.WriteLine("Digite o numero da conta que deseja remover");
                nContaRemover = int.Parse(Console.ReadLine());

                Usuario user = procurarCliente(nContaRemover);

                if (user != null) {
                    Console.Clear();
                    Console.WriteLine($"Nome: {user.Nome}\nNumero da conta: {user.NumeroConta}\nSaldo: R${user.Saldo:F2}\n\nDeseja realmente remover ?");
                    confirmacao = Console.ReadLine().ToUpper();

                    if (confirmacao == "SIM") {
                        Console.WriteLine("Digite sua senha para finalizar");
                        senhaConfirmacao = Console.ReadLine();
                        if (senhaConfirmacao == Senha) {
                            Banco.listaUsuario.Remove(user);
                            Console.Clear();
                            Console.WriteLine("Usuario deletado com sucesso\n\nPressione enter para sair!");
                            Console.ReadLine();
                        } else {
                            Console.Clear();
                            Console.WriteLine("Falha na operação\nMotivo: Senha incorreta\n\nPressione enter para sair!");
                            Console.ReadLine();
                        }
                    } else {
                        Console.Clear();
                        Console.WriteLine("Cancelando operação\n\nPressione enter para sair!");
                        Console.ReadLine();
                    }

                } else {
                    Console.Clear();
                    Console.WriteLine("Usuario não encontrado\n\nPressione enter para sair!");
                    Console.ReadLine();
                }
            } catch (Exception e){
                Console.Clear();
                Console.WriteLine("Falha na operação\nMotivo: Login informado fora dos padrões\n\nPressione enter para sair!");
                Console.ReadLine();
            }
        }

        private void listarClientes() {
            string msg = "Lista de clientes";
            int i = 1;//contador de contas

            foreach (Usuario user in Banco.listaUsuario){
                msg += $"\n{i} - \nNome: {user.Nome}\nConta: {user.NumeroConta}\n";
                i++;
            }

            Console.Clear();
            Console.WriteLine(msg + "\n\nPressione enter para sair!");
            Console.ReadLine();
        }

        private Usuario procurarCliente(int nContaRemover) {
            foreach(Usuario user in Banco.listaUsuario) {
                if(user.NumeroConta == nContaRemover) {
                    return user;
                }
            }
            return null;
        }
    }
}