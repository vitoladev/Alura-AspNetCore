﻿using System;

namespace aluraaspnetcore
{
	public class Livro
	{
		public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public Livro(string codigo, string nome, decimal preco)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
        }
    }

}
