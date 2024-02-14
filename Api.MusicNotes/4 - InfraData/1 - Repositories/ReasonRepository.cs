using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class ReasonRepository
	{
		private readonly MusicNotesDbContext _context;

		public ReasonRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<ReasonModel> GetAllEvents()
		{
			return _context.Reasons.ToList();
		}

		public List<ReasonModel> Get()
		{
			var list = new List<ReasonModel>
			{
				new ReasonModel { Id = 1, Description = "Andamento Rápido" },
				new ReasonModel { Id = 2, Description = "Andamento Lento" },
				new ReasonModel { Id = 3, Description = "Passagem para o baixo" },
				new ReasonModel { Id = 4, Description = "Passagem para o tenor" },
				new ReasonModel { Id = 5, Description = "Passagem para o contralto" },
				new ReasonModel { Id = 6, Description = "Pausa para o soprano" }
			};

			return list;
		}

		public ReasonModel GetById(int id)
		{
			var list = new List<ReasonModel>
			{
				new ReasonModel { Id = 1, Description = "Andamento Rápido" },
				new ReasonModel { Id = 2, Description = "Andamento Lento" },
				new ReasonModel { Id = 3, Description = "Passagem para o baixo" },
				new ReasonModel { Id = 4, Description = "Passagem para o tenor" },
				new ReasonModel { Id = 5, Description = "Passagem para o contralto" },
				new ReasonModel { Id = 6, Description = "Pausa para o soprano" }
			};

			return list.FirstOrDefault(x => x.Id == id);
		}

	}
}
