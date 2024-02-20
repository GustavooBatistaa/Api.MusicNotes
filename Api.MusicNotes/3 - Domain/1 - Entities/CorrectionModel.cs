using Api.MusicNotes._3___Domain._2___Enum_s;
using System.ComponentModel.DataAnnotations;

namespace Api.MusicNotes._3___Domain._1___Entities
{
	public class CorrectionModel
	{
        public CorrectionModel(DateTime occurrenceDate, int hymnId, int reasonId, EPriority priority, int groupId, int eventId)
        {
            Id = new int();
            OccurrenceDate = occurrenceDate;
            HymnId = hymnId;
            ReasonId = reasonId;
            Priority = priority;
            GroupId = groupId;
            EventId = eventId;
            Rehearsed = false;
        }
        public CorrectionModel()
		{
			Id = new int();
			Rehearsed = false;
		}
		[Display(Name = "Id")]
		public int Id { get; set; }

		[Display(Name = "Data da Ocorrência")]
		public DateTime OccurrenceDate { get; set; }

		[Display(Name = "Identificação do Hino")]
		public int HymnId { get; set; }

		public virtual HymnModel Hymn { get; set; }

		[Display(Name = "Identificação do Motivo")]
		public int ReasonId { get; set; }

		public virtual ReasonModel Reason { get; set; }

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

	
	}
}
