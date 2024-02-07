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
		new EventModel { Id = 1, Name = "Culto Oficial" },
		new EventModel { Id = 2, Name = "Reunião de Jovens e Menores" },
		new EventModel { Id = 3, Name = "Visita" }
	};

			return events;
		}

		public EventModel GetEventById(int eventId)
		{
			return _context.Events.FirstOrDefault(x => x.Id == eventId);
		}

		public void AddEvent(EventModel eventModel)
		{
			_context.Events.Add(eventModel);
			_context.SaveChanges();
		}

		public void UpdateEvent(EventModel eventModel)
		{
			_context.Events.Update(eventModel);
			_context.SaveChanges();
		}

		public void DeleteEvent(int eventId)
		{
			var eventModel = _context.Events.Find(eventId);
			if (eventModel != null)
			{
				_context.Events.Remove(eventModel);
				_context.SaveChanges();
			}
		}
	}
}
