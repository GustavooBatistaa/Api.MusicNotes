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

		public IEnumerable<ReasonModel> Get()
		{
			return _context.Reasons.ToList();
		}


		public ReasonModel GetById(int id)
		{
            var model = _context.Reasons
      .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
