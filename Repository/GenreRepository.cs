using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class GenreRepository
{
    private readonly ApplicationDbContext _context;

    public GenreRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Genre> FindAll()
    {
        return _context._genre?.ToList()?? new List<Genre>();
    }

}