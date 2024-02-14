
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class HymnModel
	{
       
		[Display(Name = "Id")]
		public int Id { get; set; }

        [Display(Name = "Descrição")]
	public string Description { get; set; }}
}
