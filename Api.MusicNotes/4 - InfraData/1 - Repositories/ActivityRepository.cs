
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Microsoft.EntityFrameworkCore;

public class ActivityRepository
{
    private readonly MusicNotesDbContext _context;

    public ActivityRepository(MusicNotesDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<ActivityModel>> GetAll(int congregationId)
    {
        return await _context.Activitys
             .Include(c => c.Organist)
         .Include(c => c.Event)
         .Include(c => c.Congregation)
         .Where(x => x.CongregationId == congregationId )
         .OrderBy(c => c.Date)
        .ToListAsync();
    }
   



    public async Task<ActivityModel> GetById(int id)
    {
        var correction = await _context.Activitys
            .Include(c => c.Organist)
            .Include(c => c.Event)
            .Include(c => c.Congregation)
            .FirstOrDefaultAsync(x => x.Id == id);

        return correction;
    }

  

    public async Task<ActivityModel> Insert(ActivityModel model)
    {
      await  _context.Activitys.AddAsync(model);
        _context.SaveChanges();
        return model;
    }


}