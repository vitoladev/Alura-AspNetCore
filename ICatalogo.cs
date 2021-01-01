using System.Collections.Generic;

namespace aluraaspnetcore
{
    public interface ICatalogo
    {
        List<Livro> GetLivros();
    }
}