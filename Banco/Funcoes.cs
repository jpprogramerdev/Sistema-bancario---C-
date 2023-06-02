using System;
using System.Runtime.Intrinsics.Arm;

namespace Banco {
    internal class Funcoes {
        Administrador adm = new();
        public void verificaAdministrador() {
            string senhaInfomarda;
            int loginInformado;
            int tentativasLogin = 1; //tentativas de logar

            Console.Clear();
            try {
                do {
                    Console.WriteLine("Digite o login:");
                    loginInformado = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nDigite a senha:");
                    senhaInfomarda = Console.ReadLine();

                    adm.Nome = "João";
                    adm.Senha = "jp12042004";
                    adm.Login = 1204;

                    if (loginInformado == adm.Login && senhaInfomarda == adm.Senha) {
                        adm.Menu();
                        break;
                    } else if (loginInformado != adm.Login || senhaInfomarda != adm.Senha) {
                        if (tentativasLogin == 3) {
                            Console.Clear();
                            Console.WriteLine("Numero maximo de tentativas atingindo!\n\nPressione enter para tentar novamente!");
                            Console.ReadLine();
                            tentativasLogin++;
                        } else {
                            Console.Clear();
                            Console.WriteLine($"Nome ou senha invalida, voce tem mais {3 - tentativasLogin} tentativas");
                            tentativasLogin++;
                        }
                    }
                } while (tentativasLogin <= 3);
            }catch (Exception e) {
                Console.Clear();
                Console.WriteLine("Login digitado fora dos padrões!\n\nPressione enter para voltar ao menu");
                Console.ReadLine();
            }
        }

        public void verificaUser() {
            int nContaInfo;
            string senhaInfo;
            int tentativasLogin = 1; //tentativas de logar

            Console.Clear();
            try {
                do {
                    Console.WriteLine("Digite o numero da conta:");
                    nContaInfo = int.Parse(Console.ReadLine());

                    Console.WriteLine("\nDigite a senha:");
                    senhaInfo = Console.ReadLine();

                    foreach (Usuario user in Banco.listaUsuario) {
                        if (nContaInfo == user.NumeroConta && senhaInfo == user.Senha) {
                            user.Menu(user);
                            break;
                        } else if (nContaInfo != adm.Login || senhaInfo != adm.Senha) {
                            if (tentativasLogin == 3) {
                                Console.Clear();
                                Console.WriteLine("Numero maximo de tentativas atingindo!\n\nPressione enter para tentar novamente!");
                                Console.ReadLine();
                                tentativasLogin++;
                            } else {
                                Console.Clear();
                                Console.WriteLine($"Nome ou senha invalida, voce tem mais {3 - tentativasLogin} tentativas");
                                tentativasLogin++;
                            }
                        }
                    }
                    break;
                } while (tentativasLogin <= 3);
            } catch (Exception e) {
                Console.Clear();
                Console.WriteLine("Login digitado fora dos padrões!\n\nPressione enter para voltar ao menu");
                Console.ReadLine();
            }
        }
    }
}