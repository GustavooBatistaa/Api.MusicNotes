namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class User
	{
		public User() { }

		public User(string name, string email, string password)
		{
			Name = name;
			Email = email;
			Password = password;
			Role = "Aluno";
		}

		public int Id { get;  set; }
		public string Name { get;  set; }
		public string Email { get;  set; }
		public string Password { get;  set; }
		public string Role { get;  set; }
	}

}
