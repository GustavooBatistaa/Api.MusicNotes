using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{
    public class EventRepository
    {
        private readonly MusicNotesDbContext _context;

        public EventRepository(MusicNotesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<EventModel>> Get()
        {
            return await _context.Events.ToListAsync();
        }

        
        public async Task<EventModel> GetEventById(int eventId)
        {
            var model = await _context.Events
            .FirstOrDefaultAsync(x => x.Id == eventId);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;

        }
    }
}
