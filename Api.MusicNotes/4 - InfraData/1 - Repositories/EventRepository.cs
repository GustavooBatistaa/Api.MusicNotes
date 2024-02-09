using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class EventRepository
	{
		private readonly MusicNotesDbContext _context;

		public EventRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<EventModel> GetAllEvents()
		{
			return _context.Events.ToList();
		}

		public List<EventModel> Get()
		{
			var events = new List<EventModel>
	{
		new EventModel { Id = 1, Description = "Culto Oficial" },
		new EventModel { Id = 2, Description = "Reunião de Jovens e Menores" },
		new EventModel { Id = 3, Description = "Visita" }
	};

			return events;
		}

		public EventModel GetEventById(int eventId)
		{
			var events = new List<EventModel>
	{
		new EventModel { Id = 1, Description = "Culto Oficial" },
		new EventModel { Id = 2, Description = "Reunião de Jovens e Menores" },
		new EventModel { Id = 3, Description = "Visita" }
	};

			return events.FirstOrDefault(x => x.Id == eventId);
		}

	}
}
