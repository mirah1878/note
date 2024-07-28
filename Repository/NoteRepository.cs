using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class NoteRepository
{
    private readonly ApplicationDbContext _context;

    public NoteRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Note> FindAll()
    {
        return _context._note?.ToList()?? new List<Note>();
    }

    public void Add(Note note)
    {
        if (note == null)
        {
            throw new ArgumentNullException(nameof(note));
        }

        _context._note.Add(note);
        _context.SaveChanges();
    }

    public void Update(Note  note)
    {
        if (note == null)
        {
            throw new ArgumentNullException(nameof(note));
        }

        _context._note.Update(note);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var noteToDelete = _context._note.Find(id);
        if (noteToDelete != null)
        {
            _context._note.Remove(noteToDelete);
            _context.SaveChanges();
        }
    }
}