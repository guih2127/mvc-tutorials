using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

// Controllers são responsáveis por fornecer os dados necessários para que uma view
// renderize a resposta. Views não devem executar lógica de negócios nem interagir
// diretamente com o banco de dados. Uma view deve funcionar apenas com os dados
// fornecidos pelo controller.


namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View(); // Metódos como esse do controller geralmente retornam uma View, 
            // a partir do IACtionResult, e não uma string como feito anteriormente.
        }

        // 
        // GET: /HelloWorld/Welcome/ 

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            // O objeto ViewData não tem nenhuma propriedade definida até que
            // se insira algo nele. Ele contém os dados que serão passados para a view.

            return View();
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