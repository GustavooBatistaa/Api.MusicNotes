using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Microsoft.VisualBasic;

namespace Api.MusicNotes._2___Services
{
	public class EventService
	{
		private readonly EventRepository _eventRepository;

		private const string MessageError = "Dados Inválidos";

		public EventService(EventRepository eventRepository)
		{
			_eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
		}


		public async Task AddEvent(EventInsertDto request)
		{
			if (request is null)
			{
				throw new ArgumentNullException(nameof(request), MessageError);
			}

			var eventModel = new EventModel();

			eventModel.Insert(request.Name);

			_eventRepository.AddEvent(eventModel);
		}

	}
}
