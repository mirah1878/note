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
    private readonly SemestreRepository semestre;
    private readonly VnoteSemestreRepository notesemestre;

     public EtudiantController(
        ApplicationDbContext context,
        ILogger<EtudiantController> logger,
        AdminRepository ad,
        EtudiantRepository et,
        SemestreRepository sem,
        VnoteSemestreRepository vn
         )
    {
        _logger = logger;
        _context = context;
        etudiant= et;
        semestre = sem;
        notesemestre = vn;
    }
   
    public IActionResult Note(string idsemestre)
    {
         string? userId = HttpContext.Session.GetString("Id"); 
         Console.WriteLine("use:"+userId+" sem: "+idsemestre);
        ViewBag.note = notesemestre.GetNote(userId,idsemestre);
        return View();
    }   
     public IActionResult Acceuil()
    {
        string? userId = HttpContext.Session.GetString("Id"); 
         Console.WriteLine("use:"+userId);
        ViewBag.semestre = semestre.FindAll();
        return View();
    }

    public IActionResult LoginEtudiant(string numetu)
    {
        string? userId = etudiant.Authenticate(numetu);
        if (!string.IsNullOrEmpty(userId))
        {
            HttpContext.Session.SetString("Id", userId);
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