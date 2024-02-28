using Api.MusicNotes._2___Application._2___DTO_s.Congregation;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Application._2___DTO_s.Organist;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._5___Config_Enum;

namespace Api.MusicNotes._2___Services
{
    public class OrganistService : BaseService
    {
        private readonly OrganistRepository _repository;
        private readonly IAppSettings _appSettings;

        public OrganistService(OrganistRepository repository, IAppSettings appSettings) : base(appSettings)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _appSettings = appSettings;
        }


        public async Task<ResultValue> GetAllCongregationId(int congregationId)
        {
            try
            {
                var list = await _repository.GetAllCongregationId(congregationId);

                if (list == null || !list.Any())
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = list.Select(item => new OrganistResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                   Christening = item.Christening,
                   MaritalStatus = item.MaritalStatus.GetDescription(),
                   Situation = item.Situation.GetDescription(),
                }).ToList();

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }
        public async Task<ResultValue> GetAll()
        {
            try
            {
                var list = await _repository.GetAll();

                if (list == null || !list.Any())
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = list.Select(item => new OrganistResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Christening = item.Christening,
                    CongregationName = item.Congregation.Name,
                    MaritalStatus = item.MaritalStatus.GetDescription(),
                    Situation = item.Situation.GetDescription(),
                }).ToList();

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> GetById(int id)
        {
            try
            {
                var model = await _repository.GetById(id);

                if (model is null)
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = new OrganistResponse
                {
                    Id = model.Id,
                    Name = model.Name,
                    Christening = model.Christening,
                    CongregationName = model.Congregation.Name,
                    MaritalStatus = model.MaritalStatus.GetDescription(),
                    Situation = model.Situation.GetDescription(),
                    
                };

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }
       
        public async Task<ResultValue> Insert(OrganistInsert request)
        {
            try
            {
                if (request is null) { return SuccessResponse(Message.MessageError); }

                var model = new OrganistModel(request.Name, request.CongregationId, request.Situation, request.Christening, request.MaritalStatus);

               await _repository.Insert(model);

                return SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }
    }
}
