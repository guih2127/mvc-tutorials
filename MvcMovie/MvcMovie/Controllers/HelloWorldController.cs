using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public string Index()
        {
            return "This is my default action...";
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }

        // Aqui, passamos parâmetros opcionais, sendo que Id será 1 por padrão,
        // mas pode ser modificado na requisição. o HtmlEncoder é utilizado para proteção
        // contra entradas mal intencionadas.
    }
}

// Cada metódo public pode ser chamado como um ponto de extremidade HTTP.
// Acima, ambos os metódos retornam strings. Se digitarmos url/hellworld/index
// veremos a primeira msg, por exemplo.
// Lógica de roteamento da URL: [Controller]/[ActionName]/[Parameters] (Está definido no startup.cs).