using Api.MusicNotes._3___Domain._2___Enum_s;
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class CorrectionModel
	{
		public CorrectionModel()
		{
			Id = new int();
			Rehearsed = false;
		}
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Data da Ocorrência")]
		public DateTime OccurrenceDate { get; set; }

		[Display(Name = "Hino")]
		public int Hymn { get; set; }

		[Display(Name = "Motivo")]
		public string Reason { get; set; }

		[Display(Name = "Prioridade")]
		public EPriority Priority { get; set; }

		[Display(Name = "Ensaiado")]
		public bool Rehearsed { get; set; }

		[Display(Name = "Identificação do Grupo")]
		public int GroupId { get; set; }

		public virtual GroupModel Group { get; set; }

		[Display(Name = "Identificação do Evento")]
		public int EventId { get; set; }
		public virtual EventModel Event { get; set; }

		public void Insert(DateTime ocurrenceDate, int hymn, string reason , EPriority priority, int groupId, int eventId)
		{
			OccurrenceDate = ocurrenceDate;
			Hymn = hymn;
			Reason = reason;
			Priority = priority;
			GroupId = groupId;
			EventId = eventId;
		}
	}
}
