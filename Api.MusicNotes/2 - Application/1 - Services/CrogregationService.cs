﻿using Api.MusicNotes._2___Application._2___DTO_s.Congregation;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Api.MusicNotes._5___Config._5___Config_Enum;

namespace Api.MusicNotes._2___Services
{
    public class CongregationService : BaseService
    {
        private readonly CongregationRepository _repository;
        private readonly IAppSettings _appSettings;

        public CongregationService(CongregationRepository repository, IAppSettings appSettings) : base(appSettings)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _appSettings = appSettings;
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

                var response = list.Select(item => new CongregationResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Sector = item.Sector.GetDescription(),
                }).ToList();

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> GetAllSector( int sector)
        {
            try
            {
                var list = await _repository.GetAllSector( sector);

                if (list == null || !list.Any())
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = list.Select(item => new CongregationResponse
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Sector = item.Sector.GetDescription(),
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

                var response = new CongregationResponse
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Sector = model.Sector.GetDescription(),
                };

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> Insert(CongregationInsert request)
        {
            try
            {
                if (request is null) { return SuccessResponse(Message.MessageError); }

                var model = new CongregationModel(request.Name, request.Description, request.Sector);

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
