using Api.MusicNotes._3___Domain._1___Entities;
using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._2___Application._2___DTO_s.Activity
{
    public class ActivityInsert
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int CongregationId { get; set; }
        public int OrganistId { get; set; }
        public EAccomplish Accomplish { get; set; }
        public DateTime Date { get; set; }
    }
}
