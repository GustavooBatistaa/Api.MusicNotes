using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.Extensions.Logging;

namespace Api.MusicNotes._4___InfraData
{
	public class FunctionRepository
	{
		private readonly MusicNotesDbContext _context;

		public FunctionRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<FunctionModel> Get()
		{
			return _context.Functions.ToList();
		}


		public FunctionModel GetById(int id)
		{
            var model = _context.Functions
           .FirstOrDefault(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
