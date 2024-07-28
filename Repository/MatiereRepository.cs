using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class MatiereRepository
{
    private readonly ApplicationDbContext _context;

    public MatiereRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Matiere> FindAll()
    {
        return _context._matiere?.ToList()?? new List<Matiere>();
    }

    public void Add(Matiere matiere)
    {
        if (matiere == null)
        {
            throw new ArgumentNullException(nameof(matiere));
        }

        _context._matiere.Add(matiere);
        _context.SaveChanges();
    }

    public void Update(Matiere  matiere)
    {
        if (matiere == null)
        {
            throw new ArgumentNullException(nameof(matiere));
        }

        _context._matiere.Update(matiere);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var matiereToDelete = _context._matiere.Find(id);
        if (matiereToDelete != null)
        {
            _context._matiere.Remove(matiereToDelete);
            _context.SaveChanges();
        }
    }
}