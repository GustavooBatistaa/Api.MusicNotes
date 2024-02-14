﻿namespace Api.MusicNotes._2___Application._2___DTO_s.Correction
{
	public class CorrectionResponse
	{
		public int Id { get; set; }
		public DateTime OccurrenceDate { get; set; }
		public int Hymn { get; set; }
		public string Reason { get; set; }
		public string Priority { get; set; }
		public bool Rehearsed { get; set; }
		public int GroupId { get; set; }
		public int EventId { get; set; }
	}
}


