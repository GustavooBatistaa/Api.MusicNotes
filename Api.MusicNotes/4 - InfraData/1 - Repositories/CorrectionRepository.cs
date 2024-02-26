﻿using System;
using System.Collections.Generic;
using System.Linq;
using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._5___Config._5___Config_Enum;
using Microsoft.EntityFrameworkCore;

public class CorrectionRepository
{
    private readonly MusicNotesDbContext _context;

    public CorrectionRepository(MusicNotesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<CorrectionModel>> GetAll(int groupId)
    {
        return await _context.Corrections
             .Include(c => c.Reason)
         .Include(c => c.Event)
         .Include(c => c.Hymn)
         .Include(c => c.Group)
         .Where(x => x.Group.Id == groupId && x.Rehearsed == false)
         .OrderBy(c => c.OccurrenceDate)
         .ThenBy(c => c.Priority == EPriority.High ? 0 : c.Priority == EPriority.Medium ? 1 : 2)
        .ToListAsync();
    }
    public async Task<List<CorrectionModel>> GetAllRehearsed(int groupId)
    {
        return await _context.Corrections
            .Include(c => c.Reason)
            .Include(c => c.Event)
            .Include(c => c.Hymn)
            .Include(c => c.Group)
            .Where(x => x.Group.Id == groupId && x.Rehearsed == true)
             .OrderBy(c => c.OccurrenceDate)
         .ThenBy(c => c.Priority == EPriority.High ? 0 : c.Priority == EPriority.Medium ? 1 : 2)
        .ToListAsync();
    }



    public async Task<CorrectionModel> GetById(int id)
    {
        var correction = await _context.Corrections
            .Include(c => c.Reason)
            .Include(c => c.Event)
            .Include(c => c.Hymn)
            .Include(c => c.Group)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (correction == null)
        {
            throw new Exception("Correção não encontrada");
        }

        return correction;
    }

    public async Task<CorrectionModel> GetByHymnId(int hymnId)
    {
        var correction = await _context.Corrections
            .Include(c => c.Reason)
            .Include(c => c.Event)
            .Include(c => c.Hymn)
            .Include(c => c.Group)
            .FirstOrDefaultAsync(x => x.Hymn.Id == hymnId);

        if (correction == null)
        {
            throw new Exception("Correção não encontrada");
        }

        return correction;
    }

    public async Task<CorrectionModel> Insert(CorrectionModel correction)
    {
      await  _context.Corrections.AddAsync(correction);
        _context.SaveChanges();
        return correction;
    }

    public async Task<CorrectionModel> UpdateAsync(CorrectionModel model, CorrectionUpdate request)
    {

        model.OccurrenceDate = request.OccurrenceDate.Date;
        model.HymnId = request.HymnId;
        model.ReasonId = request.ReasonId;
        model.Priority = request.Priority;
        model.EventId = request.EventId;

        _context.Corrections.Update(model);
        await _context.SaveChangesAsync();

        return model;
    }

    public async Task<CorrectionModel> WentToRehearse(CorrectionModel model)
    {

        model.Rehearsed = true;

        _context.Corrections.Update(model);
      await  _context.SaveChangesAsync();

        return model;
    }


}