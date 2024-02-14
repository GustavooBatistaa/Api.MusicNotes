namespace Api.MusicNotes._2___Application._2___DTO_s.Correction
{
	public class CorrectionResponse
	{
		public int Id { get; set; }
		public DateTime OccurrenceDate { get; set; }
		public int HymnId { get; set; }
		public int ReasonId { get; set; }
		public string Priority { get; set; }
		public bool Rehearsed { get; set; }
		public int GroupId { get; set; }
		public int EventId { get; set; }
	}
}


