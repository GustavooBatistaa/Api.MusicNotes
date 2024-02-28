using Api.MusicNotes._2___Application._2___DTO_s.Activity;
using Api.MusicNotes._2___Application._2___DTO_s.Congregation;
using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Application._2___DTO_s.Organist;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._5___Config_Enum;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.MusicNotes._2___Services
{
    public class ActivityService : BaseService
    {
        private readonly ActivityRepository _repository;
        private readonly IAppSettings _appSettings;

        public ActivityService(ActivityRepository repository, IAppSettings appSettings) : base(appSettings)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _appSettings = appSettings;
        }

        #region Metodos
        public async Task<ResultValue> GetAllCongregationId(int congregationId)
        {
            try
            {
                var list = await _repository.GetAll(congregationId);

                if (list == null || !list.Any())
                    return SuccessResponse(Message.NotFound);

                var response = CreateActivityResponses(list);

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
                    return SuccessResponse(Message.NotFound);

                var response = CreateActivityResponse(model);

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> Insert(ActivityInsert request)
        {
            try
            {
                if (request is null) { return SuccessResponse(Message.MessageError); }

                var model = new ActivityModel(request.EventId, request.CongregationId, request.OrganistId, request.Accomplish, request.Date);

                await _repository.Insert(model);

                return SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }
        #endregion


        #region Private
        private List<ActivityResponse> CreateActivityResponses(IEnumerable<ActivityModel> list)
        {
            return list.Select(item => new ActivityResponse
            {
                Id = item.Id,
                EventId = item.EventId,
                Accomplish = item.Accomplish,
                Date = item.Date,
                Congregation = new CongregationResponse
                {
                    Name = item.Congregation.Name,
                    Id = item.Congregation.Id,
                    Description = item.Congregation.Description,
                },
                Organist = new OrganistResponse
                {
                    Id = item.Organist.Id,
                    Name = item.Organist.Name,
                    Christening = item.Organist.Christening,
                    MaritalStatus = item.Organist.MaritalStatus.GetDescription(),
                    Situation = item.Organist.Situation.GetDescription(),
                },
                Event = new EventResponse
                {
                    Id = item.Event.Id,
                    Description = item.Event.Description
                }
            }).ToList();
        }

        private ActivityResponse CreateActivityResponse(ActivityModel model)
        {
            var congregationResponse = new CongregationResponse
            {
                Name = model.Congregation.Name,
                Id = model.Congregation.Id,
                Description = model.Congregation.Description,
            };

            var organistResponse = new OrganistResponse
            {
                Id = model.Organist.Id,
                Name = model.Organist.Name,
                Christening = model.Organist.Christening,
                MaritalStatus = model.Organist.MaritalStatus.GetDescription(),
                Situation = model.Organist.Situation.GetDescription(),
            };

            var eventResponse = new EventResponse
            {
                Id = model.Event.Id,
                Description = model.Event.Description
            };

            return new ActivityResponse
            {
                Id = model.Id,
                EventId = model.EventId,
                Accomplish = model.Accomplish,
                Date = model.Date,
                Congregation = congregationResponse,
                Organist = organistResponse,
                Event = eventResponse
            };
        }
        #endregion
    }
}
