using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class EventModel
	{
		public EventModel() { }

		public EventModel(string name)
		{
			Description = name;
		}

		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Descricao")]
		public string Description { get; set; }
	}
}
