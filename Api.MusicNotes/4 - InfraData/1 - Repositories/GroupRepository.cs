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

		public List<GroupModel> Get(int userId)
		{
            return _context.Groups.Where(x => x.UserId == userId).ToList();

       
		}

        public GroupModel GetById(int id, int userId)
        {
            var model = _context.Groups
           .FirstOrDefault(x => x.Id == id && x.UserId == userId);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }
        public GroupModel Insert(GroupModel group)
        {
            _context.Groups.Add(group);
            _context.SaveChanges();
            return group;
        }
    }
}
