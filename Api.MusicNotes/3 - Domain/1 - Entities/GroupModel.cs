namespace Api.MusicNotes._3___Domain._1___Entities
{
    public class GroupModel
    {
        public GroupModel(string name, string description, int userId)
        {
            Id = new int();
            Name = name;
            Description = description;
            UserId = userId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}
