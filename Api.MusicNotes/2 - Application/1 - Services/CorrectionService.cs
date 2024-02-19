using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._5___Config_Enum;

namespace Api.MusicNotes._2___Services
{
	public class CorrectionService : BaseService
	{
		private readonly CorrectionRepository _correctionRepository;
	
		public CorrectionService(CorrectionRepository correctionRepository, IAppSettings appSettings) : base(appSettings)
		{
			_correctionRepository = correctionRepository ?? throw new ArgumentNullException(nameof(correctionRepository));
		}


		public async Task<ResultValue> GetAll()
		{
			try
			{
				var models = _correctionRepository.GetAll();

				if (models == null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = models.Select(modelsItem => new CorrectionResponse
				{
					Id = modelsItem.Id,
					OccurrenceDate = modelsItem.OccurrenceDate,
					HymnId = modelsItem.HymnId,
					ReasonId = modelsItem.ReasonId,
					Priority = modelsItem.Priority.GetDescription(), 
					Rehearsed = modelsItem.Rehearsed,
					GroupId = modelsItem.GroupId,
					EventId = modelsItem.EventId,

				}).ToList();

				return SuccessResponse(response);
			}
			catch (Exception ex)
			{
				return ErrorResponse( ex.Message);
			
			}
		}


		public async Task<ResultValue> GetById(int id)
		{
			try
			{
				var model = _correctionRepository.GetById(id);

				if (model is null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = new CorrectionResponse
				{
					Id = model.Id,
					Rehearsed = model.Rehearsed,
					EventId = model.EventId,
					GroupId = model.GroupId,
					HymnId = model.HymnId,
					OccurrenceDate = model.OccurrenceDate,
					ReasonId = model.ReasonId,
					Priority = model.Priority.GetDescription()
				};

				return SuccessResponse(response);
			}
			catch (Exception ex)
			{
				return ErrorResponse(ex.Message);
			}
		}


	}
}
