using Microsoft.AspNetCore;
using CadAlunoTorloni.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadAlunoTorloni.Controllers
{
    public class AlunoController : Controller
    {
        private readonly ILogger<AlunoController> _logger;

        public AlunoController(ILogger<AlunoController> logger)
        {
            _logger = logger;
        }

        // Criar uma lista de Alunos
        private static List<Aluno> alunos = new List<Aluno>
        {
            new Aluno { Id = 1, Nome = "James", Idade = 18, Curso = "Informática" },
            new Aluno { Id = 2, Nome = "Samuel", Idade = 19, Curso = "Administração" },
            new Aluno { Id = 3, Nome = "Hugo", Idade = 20, Curso = "Enfermagem" },
            new Aluno { Id = 4, Nome = "Herique Nacimento", Idade = 21, Curso = "Direito" },
            new Aluno { Id = 5, Nome = "Lívia Heloisa", Idade = 22, Curso = "Engenharia" }
        };

        public IActionResult Index()
        {
            return View(alunos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Aluno aluno)
        {
            aluno.Id = alunos.Max(a => a.Id) + 1;
            alunos.Add(aluno);

            return RedirectToAction("Index");
        }

        public IActionResult AlunosMaiorIdade()
        {
            var maiores = alunos.Where(a => a.Idade >= 18).ToList();
            return View(maiores);
        }

        public IActionResult AlunosPorCurso(string curso)
        {
            var filtrados = alunos.Where(a => a.Curso == curso).ToList();
            return View(filtrados);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
