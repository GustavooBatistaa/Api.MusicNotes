using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._2___Application._2___DTO_s.Correction
{
    public class CorrectionUpdate
    {
        public DateTime OccurrenceDate { get; set; }
        public int HymnId { get; set; }
        public int ReasonId { get; set; }
        public EPriority Priority { get; set; }
        public int EventId { get; set; }
    }
}
