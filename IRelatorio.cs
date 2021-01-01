using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace aluraaspnetcore
{
    public interface IRelatorio
    {
        Task Print(HttpContext context);
    }
}