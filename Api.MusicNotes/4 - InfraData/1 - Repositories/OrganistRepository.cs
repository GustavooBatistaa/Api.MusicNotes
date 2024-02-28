
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;
using Api.MusicNotes._4___InfraData;
using Microsoft.EntityFrameworkCore;

public class OrganistRepository
{
    private readonly MusicNotesDbContext _context;

    public OrganistRepository(MusicNotesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<OrganistModel>> GetAll()
    {
        return await _context.Organists
        .ToListAsync();
    }

    public async Task<List<OrganistModel>> GetAllCongregationId( int congregationId)
    {
        return await _context.Organists.Where(x => x.CongregationId == congregationId)
        .ToListAsync();
    }


    public async Task<OrganistModel> GetById(int id)
    {
        var correction = await _context.Organists
            .FirstOrDefaultAsync(x => x.Id == id);

        return correction;
    }

  

    public async Task<OrganistModel> Insert(OrganistModel model)
    {
      await  _context.Organists.AddAsync(model);
        _context.SaveChanges();
        return model;
    }


}