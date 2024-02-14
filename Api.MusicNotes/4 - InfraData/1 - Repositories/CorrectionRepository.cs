using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._4___InfraData
{
	public class CorrectionRepository
	{
		private readonly MusicNotesDbContext _context;

		public CorrectionRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public IEnumerable<CorrectionModel> GetAll()
		{
			return _context.Corrections.ToList();
		}

		public List<CorrectionModel> Get()
		{
			var corrections = new List<CorrectionModel>
			{
		new CorrectionModel { Id = 1,OccurrenceDate = DateTime.Now,HymnId = 1,ReasonId = 1,Priority = EPriority.Medium ,EventId = 2,GroupId = 3,Rehearsed = false},
		new CorrectionModel { Id = 2,OccurrenceDate = DateTime.Now,HymnId = 3,ReasonId = 4,Priority = EPriority.High,EventId = 2,GroupId = 3,Rehearsed = false}
			};

			return corrections;
		}

		public CorrectionModel GetById(int id)
		{
			var corrections = new List<CorrectionModel>
			{
		new CorrectionModel { Id = 1,OccurrenceDate = DateTime.Now,HymnId = 1,ReasonId = 1,Priority = EPriority.Medium ,EventId = 2,GroupId = 3,Rehearsed = false},
		new CorrectionModel { Id = 2,OccurrenceDate = DateTime.Now,HymnId = 3,ReasonId = 4,Priority = EPriority.High,EventId = 2,GroupId = 3,Rehearsed = false}
			};

			return corrections.FirstOrDefault(x => x.Id == id);
		}

	}
}
