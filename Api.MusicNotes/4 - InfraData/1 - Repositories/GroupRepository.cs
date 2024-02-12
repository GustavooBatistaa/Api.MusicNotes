using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class GroupRepository
	{
		private readonly MusicNotesDbContext _context;

		public GroupRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public List<GroupModel> Get()
		{
			var groups = new List<GroupModel>
			{
				new GroupModel { Id = 1, Description = "Orquestra São Tomaz" },
				new GroupModel { Id = 2, Description = "Orquestra GEM" },
			};

			return groups;
		}

		public GroupModel GetById(int id)
		{
			var groups = new List<GroupModel>
			{
				new GroupModel { Id = 1, Description = "Orquestra São Tomaz" },
				new GroupModel { Id = 2, Description = "Orquestra GEM" },
			};

			return groups.FirstOrDefault(x => x.Id == id);
		}

	}
}
