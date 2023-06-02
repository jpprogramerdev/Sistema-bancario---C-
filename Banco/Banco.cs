using System;
using System.Collections.Generic;

namespace Banco {
    internal class Banco{
        //static pois ao instanciar Banco em Funcoes, banco fica chamando funções, funções chama banco e da stack overflow
        public static List<int> listaConta = new List<int>();
        public static List<Usuario> listaUsuario = new List<Usuario>();
        static void Main(string[] args) {
            Funcoes funcoes = new();

            int opcao = 0;

            do {
                Console.Clear();
                Console.WriteLine("Sistema Bancario\n\n1 - Administrador\n2 - Usuario\n3 - Sair\n");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao) {
                    case 1: funcoes.verificaAdministrador(); break;
                    case 2: funcoes.verificaUser(); break;
                    case 3:Console.Clear(); Console.WriteLine("Saindo do sistema");break;
                    default: Console.WriteLine("Opção invalida\n\nPressione enter para tentar novamente!"); Console.ReadLine(); break;
                }
            } while (opcao != 3);
        }
    }
}