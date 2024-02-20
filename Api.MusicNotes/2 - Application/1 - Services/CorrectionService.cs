using Api.MusicNotes._2___Application._2___DTO_s.Correction;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._5___Config_Enum;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

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

                if (models == null || !models.Any())
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = models.Select(MapToCorrectionResponse).ToList();

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
                var model = _correctionRepository.GetById(id);

                if (model is null)
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = MapToCorrectionResponse(model);

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> Insert(CorrectionInsert request)

        {
            try
            {

                if (request is null)
                {
                    return SuccessResponse(Message.MessageError);
                }

                var model = new CorrectionModel(request.OccurrenceDate.Date, request.HymnId, request.ReasonId, request.Priority, request.GroupId, request.EventId);

                _correctionRepository.Insert(model);

                return SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        #region Private

        private CorrectionResponse MapToCorrectionResponse(CorrectionModel model)
        {
            return new CorrectionResponse
            {
                Id = model.Id,
                Rehearsed = model.Rehearsed,
                Event = ToBaseDto(model.Event),
                Group = ToBaseDto(model.Group),
                Hymn = ToBaseDto(model.Hymn),
                OccurrenceDate = model.OccurrenceDate,
                Reason = ToBaseDto(model.Reason),
                Priority = model.Priority.GetDescription()
            };
        }
        private BaseDto? ToBaseDto(EventModel entity)
        {
            return entity != null ? new BaseDto { Id = entity.Id, Description = entity.Description } : null;
        }

        private BaseDto? ToBaseDto(GroupModel entity)
        {
            return entity != null ? new BaseDto { Id = entity.Id, Description = entity.Name } : null;
        }

        private BaseDto? ToBaseDto(HymnModel entity)
        {
            return entity != null ? new BaseDto { Id = entity.Id, Description = entity.Description } : null;
        }

        private BaseDto? ToBaseDto(ReasonModel entity)
        {
            return entity != null ? new BaseDto { Id = entity.Id, Description = entity.Description } : null;
        }

        #endregion
    }
}
