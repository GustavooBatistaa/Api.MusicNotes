
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;
using Api.MusicNotes._4___InfraData;
using Microsoft.EntityFrameworkCore;

public class CongregationRepository
{
    private readonly MusicNotesDbContext _context;

    public CongregationRepository(MusicNotesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<CongregationModel>> GetAll()
    {
        return await _context.Congregations
        .ToListAsync();
    }

    public async Task<List<CongregationModel>> GetAllSector(int sector)
    {
        return await _context.Congregations
            .Where(x => (int)x.Sector == sector)
            .ToListAsync();
    }

    public async Task<List<CongregationModel>> GetAllSector( ESector sector)
    {
        return await _context.Congregations.Where(x => x.Sector == sector)
        .ToListAsync();
    }


    public async Task<CongregationModel> GetById(int id)
    {
        var correction = await _context.Congregations
            .FirstOrDefaultAsync(x => x.Id == id);

        return correction;
    }

  

    public async Task<CongregationModel> Insert(CongregationModel model)
    {
      await  _context.Congregations.AddAsync(model);
        _context.SaveChanges();
        return model;
    }


}