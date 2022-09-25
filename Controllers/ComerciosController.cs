using Avaliacao3Lp3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao3Lp3.Controllers;

public class ComerciosController : Controller
{
    public static List<ComercioViewModel> comercios = new List<ComercioViewModel>();

    public IActionResult Index()
    {
        return View(comercios);
    }

    public IActionResult Gerenciamento()
    {
        return View(comercios);
    }

    public IActionResult Detalhes(int id)
    {
        return View(comercios[id - 1]);
    }

    public IActionResult Excluir(int id)
    {
        comercios.RemoveAt(id - 1);

        for(var i = id - 1; i < comercios.Count; i++)
        {
            comercios[i].Id -= 1;
        }

        return View();
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult ConfirmacaoCadastro([FromForm] string piso, [FromForm] string nome, [FromForm] string descricao, [FromForm] string tipo, [FromForm] string email)
    {
        foreach (var comercio in comercios)
        {
            if(nome == comercio.Nome)
            {
                ViewData["Titulo"] = "Cadastro negado!";
                ViewData["Mensagem"] = "O comércio já é cadastrado";
                return View();
            }
        }

        int id = 1;
        if(comercios.Count != 0) id = comercios[comercios.Count - 1].Id + 1;

        comercios.Add(new ComercioViewModel(id, piso, nome, descricao, tipo, email));

        ViewData["Titulo"] = "Cadastro aprovado!";
        ViewData["Mensagem"] = "O comércio foi cadastrado com sucesso";

        return View();
    }
}