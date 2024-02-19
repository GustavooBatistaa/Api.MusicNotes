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

		public IEnumerable<HymnModel> Get()
		{
			return _context.Hymns.ToList();
		}

		
		public HymnModel GetById(int id)
		{
            var model = _context.Hymns
         .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
