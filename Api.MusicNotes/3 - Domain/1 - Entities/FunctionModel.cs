
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class FunctionModel
	{
       
		[Display(Name = "Id")]
		public int Id { get; set; }

        [Display(Name = "Descrição")]
	public string Description { get; set; }}
}
