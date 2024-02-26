
using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{
	public class UserRepository
	{
		private readonly MusicNotesDbContext _context;

		public UserRepository(MusicNotesDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}
        public async Task<User>  Get(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return user;
        }
        public void AddUser(User model)
		{
			_context.Users.Add(model);
			_context.SaveChanges();
		}

        public  void ResetPassword(User model)
        {
            _context.Users.Update(model);
            _context.SaveChanges();
        }

        public  User GetByEmail(string email)
		{
            var user =  _context.Users.FirstOrDefault(x => x.Email == email);
            return user;
        }

	}




}


