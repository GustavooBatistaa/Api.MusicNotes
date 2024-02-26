
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
        public async Task AddUser(User model)
        {
            await _context.Users.AddAsync(model);
            _context.SaveChanges();
        }

        public async Task ResetPassword(User model)
        {
            _context.Users.Update(model);
           await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
		{
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

	}




}


