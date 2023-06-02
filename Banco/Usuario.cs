using Banco;
using System;

namespace Banco {
    internal class Usuario : Pessoa {
        private int _numConta;
        private double _saldo;

        public Usuario(string nomeUsuario,int numeroConta, string senha, double saldo) {
            Nome = nomeUsuario;
            NumeroConta = numeroConta;
            Senha = senha;
            Saldo = saldo;
        }

        public int NumeroConta {
            get { return _numConta; }
            set { _numConta = value; }
        }

        public double Saldo {
            get { return _saldo; }
            set { _saldo = value; }
        }

        public void Menu(Usuario user) {
            int opcao;
            do {
                Console.Clear();

                Console.WriteLine($"Bem vindo usuario {user.Nome}\n\n");

                Console.WriteLine("O que deseja fazer?\n1 - Ver saldo\n2 - Sacar dinheiro\n3 - Adicionar dinheiro\n4 - Transferir dinheiro\n5 - Sair\n");
                opcao = int.Parse(Console.ReadLine());
                switch (opcao) {
                    case 1: exibirSaldo(user); break;
                    case 2: sacarDinheiro(user);break;
                    case 3: addSaldo(user);break;
                    case 4: transacaoDinheiro(user);break;
                    case 5: Console.Clear(); Console.WriteLine("Saindo ..."); Console.ReadLine();break;
                    default: Console.WriteLine("Opção invalida\n\nPressione enter para tentar novamente!"); Console.ReadLine(); break;
                }
            } while (opcao != 5);  
        }

        private void exibirSaldo(Usuario user) {
            Console.Clear();
            Console.WriteLine($"Saldo disponivel: R${user.Saldo:F2}\n\nPressione enter para sair!");
            Console.ReadLine();
        }

        private void sacarDinheiro(Usuario user) {
            double valorSaque;
            string senhaConfirmacao;

            Console.Clear();

            try {
                Console.WriteLine("Digite o valor do saque");
                valorSaque = double.Parse(Console.ReadLine());

                if (valorSaque > user.Saldo) {
                    Console.Clear();
                    Console.WriteLine("Saque negado!\nMotivo: Saldo insuficiente\n\nPressione enter para sair!");
                    Console.ReadLine();
                } else {
                    Console.WriteLine("Digite sua senha para confirmar");
                    senhaConfirmacao = Console.ReadLine();

                    if (senhaConfirmacao == user.Senha) {
                        Console.Clear();
                        Console.WriteLine($"Saque autorizado!\n\nSaldo atual: R${subtrairSaldo(user, valorSaque):F2} \n\nPressione enter para sair!");
                        Console.ReadLine();
                    } else {
                        Console.Clear();
                        Console.WriteLine("Saque negado!\nMotivo: Senha incorreta\nPressione enter para sair!");
                        Console.ReadLine();
                    }
                }
            } catch (Exception e) {
                Console.Clear();
                Console.WriteLine("[ERRO] Foi digitado uma letra no valor a ser sacado\n\nPressione enter para voltar ao menu!");
                Console.ReadLine();
            }
        }

        private void addSaldo(Usuario user) {
            double valorAdd;
            string senhaConfirmacao;

            Console.Clear();
            try {
                Console.WriteLine("Digite o valor a ser adicionado");
                valorAdd = double.Parse(Console.ReadLine());

                Console.WriteLine("\nDigite sua senha para confirmar");
                senhaConfirmacao = Console.ReadLine();

                Console.Clear();

                if (senhaConfirmacao == user.Senha) {
                    Console.WriteLine($"Valor adicionado!\nSaldo atual: R${atualizarSaldo(user, valorAdd):F2}\n\nPressione enter para sair!");
                    Console.ReadLine();
                } else {
                    Console.WriteLine("Não foi possivel adiconar o saldo solicitado!\nMotivo:Senha incorreta\n\nPressione enter para sair!");
                    Console.ReadLine();
                }
            }catch (Exception e) {
                Console.Clear();
                Console.WriteLine("[ERRO] Foi digitado uma letra no valor a ser adicionado\n\nPressione enter para voltar ao menu!");
                Console.ReadLine();
            }
        }

        private void transacaoDinheiro(Usuario userOrigem) {
            double valorTransferencia;
            string senhaConfirmacao;
            int contaTransferir;

            Console.Clear();
            try { 
                Console.WriteLine("Digite a conta que seja transferir");
                contaTransferir = int.Parse(Console.ReadLine());
                Usuario userfinal = encontrarUser(contaTransferir);

                if (userfinal != null) {
                    Console.Clear();
                    Console.WriteLine($"\nConta: {userfinal.NumeroConta}\nNome: {userfinal.Nome}");
                    Console.WriteLine("\nDigite o valor a ser transferido");
                    valorTransferencia = double.Parse(Console.ReadLine());

                    if (valorTransferencia > userOrigem.Saldo) {
                        Console.Clear();
                        Console.WriteLine("Transferencia negada!\nMotivo: Saldo insuficiente\n\nPressione enter para sair!");
                        Console.ReadLine();
                    } else {
                        Console.WriteLine("Digite a sua senha");
                        senhaConfirmacao = Console.ReadLine();

                        if (senhaConfirmacao == userOrigem.Senha) {
                            Console.Clear();
                            subtrairSaldo(userOrigem, valorTransferencia);
                            atualizarSaldo(userfinal, valorTransferencia);
                            Console.WriteLine($"Tranferencia autorizada\nSaldo atual: R${userOrigem.Saldo:F2}\n\nPressione enter para sair!");
                            Console.ReadLine();
                        } else {
                            Console.Clear();
                            Console.WriteLine("Tranferencia negada\nMotivo: Senha incorreta\n\nPressione enter para sair!");
                            Console.ReadLine();
                        }
                    }
                } else {
                    Console.Clear();
                    Console.WriteLine("Usuario não encontrado\n\nPressione enter para sair!");
                    Console.ReadLine();
                }
            } catch (Exception e) {
                Console.Clear();
                Console.WriteLine("[ERRO] Foi digitado uma letra no valor a ser adicionado\n\nPressione enter para voltar ao menu!");
                Console.ReadLine();
            }
        }

        private double subtrairSaldo(Usuario user, double valorSaque) {
            user.Saldo -= valorSaque;
            return user.Saldo;
        }
        
        private double atualizarSaldo(Usuario user, double valoAdd) {
            user.Saldo += valoAdd;
            return user.Saldo;
        }
        
        private Usuario encontrarUser(int contaTransferir) {
            foreach (Usuario userFinal in Banco.listaUsuario) {
                if (userFinal.NumeroConta == contaTransferir) {
                    return userFinal;
                }
            }
            return null;
        }
    }
}