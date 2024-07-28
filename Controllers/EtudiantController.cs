using System.Data;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Microsoft.EntityFrameworkCore;


namespace Mvc.Controllers;
//[ServiceFilter(typeof(CustomAuthorizationFilter))]
public class EtudiantController : Controller
{
    private readonly ILogger<EtudiantController> _logger;
    private readonly ApplicationDbContext _context;
     private readonly EtudiantRepository etudiant;

     public EtudiantController(
        ApplicationDbContext context,
        ILogger<EtudiantController> logger,
        AdminRepository ad,
        EtudiantRepository et
        )
    {
        _logger = logger;
        _context = context;
        etudiant= et;

    }
   
     public IActionResult Acceuil()
    {
        ViewBag.UserId = TempData["UserId"] as string;
        return View();
    }

    public IActionResult LoginEtudiant(string numetu)
    {
        string? userId = etudiant.Authenticate(numetu);
        if (!string.IsNullOrEmpty(userId))
        {
            TempData["UserId"] = userId; 
            return RedirectToAction("Acceuil", "Etudiant");
        }
        else
        {
            return RedirectToAction("Acceuil", "Etudiant");
        }
    }



    public IActionResult Index()
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"];
        return View();
    }

        

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}