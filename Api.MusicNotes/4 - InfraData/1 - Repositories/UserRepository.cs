
using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public class UserRepository
	{
		private readonly MusicNotesDbContext _context;

		public UserRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public User Get(string email, string password)
		{

			var user = new User { Id = 1, Name = "Gustavo", Email = "gustavobatistaosp@gmail.com", Password = "1122", Role = "Manager" };


			return user; /*_context.Users.FirstOrDefault(x => x.Name.ToLower() == userName.ToLower() && x.Password == password);*/
		}

		public void AddUser(User model)
		{
			_context.Users.Add(model);
			_context.SaveChanges();
		}


		public User GetByEmail(string email)
		{
			var users = new List<User>
			{
				new User { Id = 1, Name = "Gustavo", Email = "gustavobatistaosp@gmail.com", Password = "1122", Role = "Manager" }
			};

			return users.FirstOrDefault(x => x.Email == email);
		}

	}




}


