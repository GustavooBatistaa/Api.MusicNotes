using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{
	public class HymnRepository
	{
		private readonly MusicNotesDbContext _context;

		public HymnRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

        public async Task<List<HymnModel>> GetAll()
        {
			return await _context.Hymns.ToListAsync();
		}

		
		public async Task<HymnModel> GetById(int id)
		{
            var model = await _context.Hymns
         .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
