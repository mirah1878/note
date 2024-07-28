using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class EtudiantRepository
{
    private readonly ApplicationDbContext _context;

    public EtudiantRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Etudiant> FindAll()
    {
        return _context._etudiant?.ToList()?? new List<Etudiant>();
    }

    public void Add(Etudiant etudiant)
    {
        if (etudiant == null)
        {
            throw new ArgumentNullException(nameof(etudiant));
        }

        _context._etudiant.Add(etudiant);
        _context.SaveChanges();
    }

    public void Update(Etudiant  etudiant)
    {
        if (etudiant == null)
        {
            throw new ArgumentNullException(nameof(etudiant));
        }

        _context._etudiant.Update(etudiant);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var etudiantToDelete = _context._etudiant.Find(id);
        if (etudiantToDelete != null)
        {
            _context._etudiant.Remove(etudiantToDelete);
            _context.SaveChanges();
        }
    }
    public string? Authenticate(string numetu)
    {
        var selectAll = this.FindAll();
        foreach (var adm in selectAll)
        {
            if (adm.NumEtu == numetu)
            {
                return adm.Id;
            }
        }
        return null; 
    }
}