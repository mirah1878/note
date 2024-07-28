using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class VnoteSemestreRepository
{
    private readonly ApplicationDbContext _context;

    public VnoteSemestreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<VnoteEtudiantParSemestre> FindAll()
    {
        return _context._vnoteEtudiantParSemestre?.ToList()?? new List<VnoteEtudiantParSemestre>();
    }
    
}