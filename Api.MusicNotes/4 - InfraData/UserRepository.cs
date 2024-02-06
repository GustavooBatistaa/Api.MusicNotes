using Api.MusicNotes._3___Domain._1___Entities;

namespace Api.MusicNotes._4___InfraData
{
	public static class UserRepository
	{
		public static User Get(string username, string password)
		{
			var users = new List<User>
		{
			new User { Id = 1, UserName = "Gustavo", Password = "1234", Role = "manager" },
			new User { Id = 2, UserName = "Stefany", Password = "1234", Role = "manager" },
			new User { Id = 3, UserName = "Laura", Password = "1234", Role = "employee" }
		};

			return users.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower() && x.Password == password);
		}
	}
}
