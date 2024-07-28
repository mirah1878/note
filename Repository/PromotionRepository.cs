using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class PromotionRepository
{
    private readonly ApplicationDbContext _context;

    public PromotionRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public List<Promotion> FindAll()
    {
        return _context._promotion?.ToList()?? new List<Promotion>();
    }

    public void Add(Promotion promotion)
    {
        if (promotion == null)
        {
            throw new ArgumentNullException(nameof(promotion));
        }

        _context._promotion.Add(promotion);
        _context.SaveChanges();
    }

    public void Update(Promotion  promotion)
    {
        if (promotion == null)
        {
            throw new ArgumentNullException(nameof(promotion));
        }

        _context._promotion.Update(promotion);
        _context.SaveChanges();
    }

    public void Delete(string id)
    {
        var promotionToDelete = _context._promotion.Find(id);
        if (promotionToDelete != null)
        {
            _context._promotion.Remove(promotionToDelete);
            _context.SaveChanges();
        }
    }
}