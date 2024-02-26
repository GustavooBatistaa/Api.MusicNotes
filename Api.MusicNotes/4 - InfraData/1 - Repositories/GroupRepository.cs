using Api.MusicNotes._3___Domain._1___Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.MusicNotes._4___InfraData
{
    public class GroupRepository
    {
        private readonly MusicNotesDbContext _context;

        public GroupRepository(MusicNotesDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<GroupModel>> GetAll(int userId)
        {
            return await _context.Groups.Where(x => x.UserId == userId).ToListAsync();


        }

        public async Task<GroupModel> GetById(int id, int userId)
        {
            var model = await _context.Groups
           .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);

            if (model == null)
            {
                throw new Exception("Não encontrada");
            }

            return model;
        }
        public async Task<GroupModel> Insert(GroupModel group)
        {
            await _context.Groups.AddAsync(group);
            _context.SaveChanges();
            return group;
        }
    }
}
