using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{

	public class MusicNotesDbContext : DbContext
	{
		public MusicNotesDbContext(DbContextOptions<MusicNotesDbContext> options) : base(options)
		{

		}
		public DbSet<EventModel> Events { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<GroupModel> Groups { get; set; }
		public DbSet<CorrectionModel> Corrections { get; set; }
		public DbSet<FunctionModel> Functions { get; set; }
		public DbSet<HymnModel> Hymns { get; set; }
		public DbSet<OrganistModel> Organists { get; set; }
		public DbSet<ActivityModel> Activitys { get; set; }
		public DbSet<CongregationModel> Congregations { get; set; }
		public DbSet<ReasonModel> Reasons { get; set; }
	}
	}

