using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class HymnRepository
	{
		private readonly MusicNotesDbContext _context;

		public HymnRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<HymnModel> GetAllEvents()
		{
			return _context.Hymns.ToList();
		}

		public List<HymnModel> Get()
		{
			var list = new List<HymnModel>
			{
		new HymnModel { Id = 1, Description = "1 - Cristo, meu Mestre" },
		new HymnModel { Id = 2, Description = "2 - De Deus tu és eleita" },
		new HymnModel { Id = 3, Description = "139 - Ó Senhor, Tu me conheces" },
		new HymnModel { Id = 4, Description = "140 - Sou Feliz" }
			};

			return list;
		}

		public HymnModel GetById(int id)
		{
			var list = new List<HymnModel>
			{
		new HymnModel { Id = 1, Description = "1 - Cristo, meu Mestre" },
		new HymnModel { Id = 2, Description = "2 - De Deus tu és eleita" },
		new HymnModel { Id = 3, Description = "139 - Ó Senhor, Tu me conheces" },
		new HymnModel { Id = 4, Description = "140 - Sou Feliz" }
			};

			return list.FirstOrDefault(x => x.Id == id);
		}

	}
}
