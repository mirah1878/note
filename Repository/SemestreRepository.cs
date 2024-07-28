using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class SemestreRepository
{
    private readonly ApplicationDbContext _context;

    public SemestreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Semestre> FindAll()
    {
        return _context._semestre?.ToList()?? new List<Semestre>();
    }

    public void Add(Semestre semestre)
    {
        if (semestre == null)
        {
            throw new ArgumentNullException(nameof(semestre));
        }

        _context._semestre.Add(semestre);
        _context.SaveChanges();
    }

    public void Update(Semestre  semestre)
    {
        if (semestre == null)
        {
            throw new ArgumentNullException(nameof(semestre));
        }

        _context._semestre.Update(semestre);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var semestreToDelete = _context._semestre.Find(id);
        if (semestreToDelete != null)
        {
            _context._semestre.Remove(semestreToDelete);
            _context.SaveChanges();
        }
    }
}