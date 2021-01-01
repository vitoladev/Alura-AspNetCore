using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace aluraaspnetcore
{
    public class Relatorio
    {
        private readonly Catalogo Catalogo;

        public Relatorio(Catalogo catalogo)
        {
            Catalogo = catalogo;
        }

        public async Task Print(HttpContext context)
        {
            var livros = Catalogo.GetLivros();
            foreach (var livro in livros)
            {
                await context.Response.WriteAsync($"{livro.Codigo,-10} {livro.Nome,-40} {livro.Preco.ToString("C"),10}\r \n");
            }
        }
    }
}