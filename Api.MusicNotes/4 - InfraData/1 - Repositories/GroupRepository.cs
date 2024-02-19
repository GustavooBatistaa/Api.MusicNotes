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
            return _context.Groups.ToList();

       
		}

        public GroupModel GetById(int id)
        {
            var model = _context.Groups
           .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

    }
}
