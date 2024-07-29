using System.Data;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using Microsoft.EntityFrameworkCore;


namespace Mvc.Controllers;
//[ServiceFilter(typeof(CustomAuthorizationFilter))]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly AdminRepository admin;
    private readonly EtudiantRepository etudiant;
    
    private readonly Import csv;
   

    public AdminController(
        ApplicationDbContext context,
        ILogger<AdminController> logger,
        AdminRepository ad,
        EtudiantRepository et,
        Import _csv
        )
    {
        _logger = logger;
        _context = context;
        admin = ad;
        etudiant = et;
       csv = _csv;
    }

    public IActionResult ImportNote(IFormFile note)
    {
        if(note!= null){
            csv.ImportCsvToDatabase("note_temporaire",note,NoteTemporaire.MapNoteTemporaire);
            csv.InsertDataNote();
            return RedirectToAction("Acceuil", "Admin"); 
        }else{
            TempData["ErrorMessage"] = "le fichier ne doit pas etre null";
            return RedirectToAction("PageImportNote","");
        }
    }

    public IActionResult PageImportNote()
    {
        return View();
    }
        
    public IActionResult Acceuil()
    {
        return View();
    }

    public IActionResult LoginAdmin(string nom, string password)
    {
         string? userId = admin.Authenticate(nom, password);
         if (!string.IsNullOrEmpty(userId))
            {
                HttpContext.Session.SetString("Id", userId);
                return RedirectToAction("Acceuil", "Admin"); 
            }
            else
            {
                TempData["ErrorMessage"] = "Adresse email ou mot de passe incorrect.";
                return RedirectToAction("Index","Admin");
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