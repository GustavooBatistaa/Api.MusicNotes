using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class FunctionRepository
	{
		private readonly MusicNotesDbContext _context;

		public FunctionRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<FunctionModel> GetAllEvents()
		{
			return _context.Functions.ToList();
		}

		public List<FunctionModel> Get()
		{
			var list = new List<FunctionModel>
			{
		new FunctionModel { Id = 1, Description = "Encarregado Local" },
		new FunctionModel { Id = 2, Description = "Encarregado Regional" },
		new FunctionModel { Id = 3, Description = "Instrutor" },
		new FunctionModel { Id = 4, Description = "Candidato" }
			};

			return list;
		}

		public FunctionModel GetById(int id)
		{
			var functions = new List<FunctionModel>
			{
		new FunctionModel { Id = 1, Description = "Encarregado Local" },
		new FunctionModel { Id = 2, Description = "Encarregado Regional" },
		new FunctionModel { Id = 3, Description = "Instrutor" },
		new FunctionModel { Id = 4, Description = "Candidato" }
			};

			return functions.FirstOrDefault(x => x.Id == id);
		}

	}
}
