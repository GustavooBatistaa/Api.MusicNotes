using Api.MusicNotes._2___Application._2___DTO_s.Events;
using Api.MusicNotes._2___Application._2___DTO_s.Group;
using Api.MusicNotes._2___Application._2___DTO_s.Hymn;
using Api.MusicNotes._5___Config._3___Utils;

namespace Api.MusicNotes._2___Application._2___DTO_s.Correction
{
	public class CorrectionResponse
	{
		public int Id { get; set; }
		public DateTime OccurrenceDate { get; set; }
		public BaseDto Hymn { get; set; }
		public BaseDto Reason { get; set; }
		public string Priority { get; set; }
		public bool Rehearsed { get; set; }
		public BaseDto Group { get; set; }
		public BaseDto Event { get; set; }
	}
}


