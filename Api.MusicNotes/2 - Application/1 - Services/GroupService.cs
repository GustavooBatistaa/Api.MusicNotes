using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;

namespace Api.MusicNotes._2___Services
{
    public class GroupService : BaseService
    {
        private readonly GroupRepository _groupRepository;
        private readonly IAppSettings _appSettings;

        public GroupService(GroupRepository groupRepository, IAppSettings appSettings) : base(appSettings)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _appSettings = appSettings;
        }


        public async Task<ResultValue> GetGroups(int userId)
        {
            try
            {
                var groups = await _groupRepository.GetAll(userId);

                if (groups == null || !groups.Any())
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = groups.Select(groupItem => new GroupResponse
                {
                    Id = groupItem.Id,
                    Name = groupItem.Name,
                    Description = groupItem.Description,
                }).ToList();

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }


        public async Task<ResultValue> GetById(int id, int userId)
        {
            try
            {
                var group = await _groupRepository.GetById(id, userId);

                if (group is null || group.UserId != userId)
                {
                    return SuccessResponse(Message.NotFound);
                }

                var response = new GroupResponse
                {
                    Id = group.Id,
                    Name = group.Name,
                    Description = group.Description,
                };

                return SuccessResponse(response);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }

        public async Task<ResultValue> Insert(GroupInsert request)
        {
            try
            {
                if (request is null) { return SuccessResponse(Message.MessageError); }

                var model = new GroupModel(request.Name, request.Description, request.UserId);

               await _groupRepository.Insert(model);

                return SuccessResponse(model);
            }
            catch (Exception ex)
            {
                return ErrorResponse(ex.Message);
            }
        }
    }
}
