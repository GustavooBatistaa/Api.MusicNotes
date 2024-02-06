using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Reflection.Emit;

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
		
		}
	}

