using System;

namespace Banco {
    internal class Pessoa {
        protected string _nome;
        protected string _senha;

        public string Nome {
            get { return _nome; }
            set { _nome = value; }
        }
        public string Senha {
            get { return _senha; }
            set { _senha = value; }
        }

        public virtual void Menu() { }
    }
}
