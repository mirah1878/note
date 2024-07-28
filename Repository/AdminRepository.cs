using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class AdminRepository
{
    private readonly ApplicationDbContext _context;

    public AdminRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Admin> FindAll()
    {
        return _context._admin?.ToList()?? new List<Admin>();
    }

    public void Add(Admin admin)
    {
        if (admin == null)
        {
            throw new ArgumentNullException(nameof(admin));
        }

        _context._admin.Add(admin);
        _context.SaveChanges();
    }

    public void Update(Admin  admin)
    {
        if (admin == null)
        {
            throw new ArgumentNullException(nameof(admin));
        }

        _context._admin.Update(admin);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var adminToDelete = _context._admin.Find(id);
        if (adminToDelete != null)
        {
            _context._admin.Remove(adminToDelete);
            _context.SaveChanges();
        }
    }

    public string? Authenticate(string nom, string password)
    {
        var selectAll = this.FindAll();
        foreach (var adm in selectAll)
        {
            if (adm.Nom == nom && adm.Password == password)
            {
                return adm.Id;
            }
        }
        return null; 
    }
    
}