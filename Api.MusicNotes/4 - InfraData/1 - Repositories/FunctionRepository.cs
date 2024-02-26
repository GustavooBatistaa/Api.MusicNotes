using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<FunctionModel>> Get()
		{
			return await _context.Functions.ToListAsync();
		}


        public async Task<FunctionModel> GetById(int id)
		{
            var model = await _context.Functions
           .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
