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
    public IEnumerable<VnoteEtudiantParSemestre> GetNote(string? idetudiant, string? idsemestre)
    {
        return _context._vnoteEtudiantParSemestre
            .Where(v => v.Id == idetudiant && v.IdSemestre == idsemestre)
            .ToList();
    }


    public List<VnoteEtudiantParSemestre> FindAll()
    {
        return _context._vnoteEtudiantParSemestre?.ToList()?? new List<VnoteEtudiantParSemestre>();
    }
    
}