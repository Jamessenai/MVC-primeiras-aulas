using System.Threading.Tasks;
using DevConnectTorloni.Contexts;
using DevConnectTorloni.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevConnectTorloni.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly DevConnectContext _context;
        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger, DevConnectContext
        context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form)
        {
            // Console.WriteLine($"{form["NomeCompleto"]}");
            //  Console.WriteLine($"{form.Files[0].FileName}");

            Usuario novoUsuario = new Usuario
            {
                NomeCompleto = form["NomeCompleto"].ToString(),
                NomeUsuario = form["NomeUsuario"].ToString(),
                Email = form["Email"].ToString(),
                Senha = form["Senha"].ToString()
            };

            if (form.Files.Count > 0)
            {
                var file = form.Files[0];
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(folder, file.FileName);

                using(var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                novoUsuario.FotoPerfilUrl = file.FileName;
            }
            else
            {
                novoUsuario.FotoPerfilUrl = "";
            }

            try
            {
                //Adiciona um novo usuário na tabela Usuário
                _context.Usuario.Add(novoUsuario);
                
                //Salva no banco de dados as alterações feitas
                await _context.SaveChangesAsync();
                
                TempData["UsuarioNovoCadastrado"] = "Cadastro";
                ViewBag.UsuarioNovoCadastrado = "";

                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception)
            {
                ViewBag.UsuarioNovoCadastrado = "Nao cadastrado";
                TempData["UsuarioNovoCadastrado"] = "";
                //vamos pedir para a view falar ao usuário que não foi cadastrado 
                return View();
               
            }

        }

        public IActionResult Perfil()
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