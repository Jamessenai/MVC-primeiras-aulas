using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadAlunoTorloni.Controllers
{
    public class FrutasController : Controller
    {
        private readonly ILogger<FrutasController> _logger;

        public FrutasController(ILogger<FrutasController> logger)
        {
            _logger = logger;
        }





        // Criar uma lista de Frutas
        private static List<Fruta> frutas= new List<Fruta>
        {
            new Fruta { Id = 1, Nome = "Maça", Cor = "Vermelha", Categoria = "Tropical"},
            new Fruta { Id = 2, Nome = "Uva", Cor = "Roxa", Categoria = "Tropical"},
            new Fruta { Id = 3, Nome = "Melancia", Cor = "Verde", Categoria = "Tropical"},
            new Fruta { Id = 4, Nome = "Melao", Cor = "Amarelo", Categoria = "Tropical"},
            new Fruta { Id = 5, Nome = "Kiwi", Cor = "Marron", Categoria = "Tropical"},
        };

        public IActionResult Index()
        {
            return View(frutas);
        }

        public IActionResult Create()
        {
            return View();
        }


        // Método para salvar uma fruta, sem uma view 
        [HttpPost]
        public IActionResult Create(Fruta fruta)
        {
            fruta.Id = frutas.Max(f => f.Id) + 1;
            // salvar no array 
            frutas.Add(fruta);
            // redirecionar o usuário para a Index
            return RedirectToAction("Index");
        }
        public IActionResult FrutasCitricas()
        {
            return View();
        }
        public IActionResult FrutasTropical()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}