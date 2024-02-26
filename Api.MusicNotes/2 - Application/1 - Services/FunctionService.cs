using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;

namespace Api.MusicNotes._2___Services
{
	public class FunctionService : BaseService
	{
		private readonly FunctionRepository _functionRepository;
		private readonly IAppSettings _appSettings;

		public FunctionService(FunctionRepository functionRepository, IAppSettings appSettings) : base(appSettings)
		{
			_functionRepository = functionRepository ?? throw new ArgumentNullException(nameof(functionRepository));
			_appSettings = appSettings;
		}


		public async Task<ResultValue> GetFunctions()
		{
			try
			{
				var functions = await _functionRepository.Get();

				if (functions == null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var functionResponse = functions.Select(functionItem => new FunctionResponse
				{
					Id = functionItem.Id,
					Description = functionItem.Description,
				}).ToList();

				return SuccessResponse(functionResponse);
			}
			catch (Exception ex)
			{
				return ErrorResponse( ex.Message);
			
			}
		}


		public async Task<ResultValue> GetFunctionById(int id)
		{
			try
			{
				var function = await _functionRepository.GetById(id);

				if (function is null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = new FunctionResponse
				{
					Id = function.Id,
					Description = function.Description,
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
