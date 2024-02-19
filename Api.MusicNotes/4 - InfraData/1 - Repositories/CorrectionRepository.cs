using System;
using System.Collections.Generic;
using System.Linq;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Microsoft.EntityFrameworkCore;

public class CorrectionRepository
{
    private readonly MusicNotesDbContext _context;

    public CorrectionRepository(MusicNotesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<CorrectionModel> GetAll()
    {
        return _context.Corrections
            .Include(c => c.Reason)
            .Include(c => c.Event)
            .Include(c => c.Hymn)
            .Include(c => c.Group)
            .ToList();
    }

    public CorrectionModel GetById(int id)
    {
        var correction = _context.Corrections
            .Include(c => c.Reason)
            .Include(c => c.Event)
            .Include(c => c.Hymn)
            .Include(c => c.Group)
            .FirstOrDefault(x => x.Id == id);

        if (correction == null)
        {
            throw new Exception("Correção não encontrada");
        }

        return correction;
    }
}