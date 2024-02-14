using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;

namespace Api.MusicNotes._2___Services
{
	public class EventService : BaseService
	{
		private readonly EventRepository _eventRepository;
		private readonly IAppSettings _appSettings;

		public EventService(EventRepository eventRepository, IAppSettings appSettings) : base(appSettings)
		{
			_eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
			_appSettings = appSettings;
		}


		public async Task<ResultValue> GetEvents()
		{
			try
			{
				var events = _eventRepository.Get();

				if (events == null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var eventResponse = events.Select(eventItem => new EventResponse
				{
					Id = eventItem.Id,
					Description = eventItem.Description,
				}).ToList();

				return SuccessResponse(eventResponse);
			}
			catch (Exception ex)
			{
				return ErrorResponse( ex.Message);
			
			}
		}


		public async Task<ResultValue> GetEventById(int id)
		{
			try
			{
				var eventm = _eventRepository.GetEventById(id);

				if (eventm is null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var eventResponse = new EventResponse
				{
					Id = eventm.Id,
					Description = eventm.Description,
				};

				return SuccessResponse(eventResponse);
			}
			catch (Exception ex)
			{
				return ErrorResponse(ex.Message);
			}
		}


	}
}
