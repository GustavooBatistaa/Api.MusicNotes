using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.Function;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._4___InfraData;
using Api.MusicNotes._4___InfraData._2___AppSettings;
using Api.MusicNotes._5___Config._3___Utils;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.ComponentModel;

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


		public async Task<ResultValue> GetGroups()
		{
			try
			{
				var groups = _groupRepository.Get();

				if (groups == null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = groups.Select(groupItem => new GroupResponse
				{
					Id = groupItem.Id,
					Description = groupItem.Description,
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
				var group = _groupRepository.GetById(id);

				if (group is null)
				{
					return SuccessResponse(Message.NotFound);
				}

				var response = new GroupResponse
				{
					Id = group.Id,
					Description = group.Description,
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
