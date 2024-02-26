using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{
	public class ReasonRepository
	{
		private readonly MusicNotesDbContext _context;

		public ReasonRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public async Task<List<ReasonModel>> GetAll()
		{
			return await _context.Reasons.ToListAsync();
		}


		public async  Task<ReasonModel> GetById(int id)
		{
            var model = await _context.Reasons
      .FirstOrDefaultAsync(x => x.Id == id);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }

	}
}
