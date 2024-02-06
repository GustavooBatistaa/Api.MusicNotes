namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class GroupModel
	{
        public GroupModel()
        {
            Id = new int();
        }
        public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public void Insert(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
