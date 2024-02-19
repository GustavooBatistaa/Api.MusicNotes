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

        public IEnumerable<EventModel> Get()
        {
            return _context.Events.ToList();
        }

        
        public EventModel GetEventById(int eventId)
        {
            var model = _context.Events
            .FirstOrDefault(x => x.Id == eventId);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;

        }
    }
}
