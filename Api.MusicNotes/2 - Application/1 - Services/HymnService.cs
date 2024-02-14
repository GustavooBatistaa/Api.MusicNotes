using Api.MusicNotes._2___Application._2___DTO_s.Hymn;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;

namespace Api.MusicNotes._2___Services
{
	public class HymnService : BaseService
	{
		private readonly HymnRepository _hymnRepository;
		
		public HymnService(HymnRepository hymnRepository, IAppSettings appSettings) : base(appSettings)
		{
			_hymnRepository = hymnRepository ?? throw new ArgumentNullException(nameof(hymnRepository));
			_appSettings = appSettings;
		}


		public async Task<ResultValue> GetAll()
		{
			try
			{
				var modelList = _hymnRepository.Get();

				if (modelList == null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = modelList.Select(item => new HymnResponse
				{
					Id = item.Id,
					Description = item.Description,
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
				var model = _hymnRepository.GetById(id);

				if (model is null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = new HymnResponse
				{
					Id = model.Id,
					Description = model.Description,
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
