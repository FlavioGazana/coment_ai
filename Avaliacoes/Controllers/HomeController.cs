using Microsoft.AspNetCore.Mvc;

namespace Avaliacoes.Controllers
{
    public class HomeController : Controller //a home controller é responsável por direcionar o conteúdo do backend a ser exibido
 //antes de chegar ao navegador 
    {
        public IActionResult Index() // o actionresult é um tipo de retorno que indica ao projeto o que responder ao navegador quando
            //determinado tipo de requisição HTTP é feita
        {
            return View();
        }
    }
}
