using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._3___Domain._1___Entities
{
    public class ActivityModel
    {
        public ActivityModel(){}

        public ActivityModel(int eventId, int congregationId, int organistId, EAccomplish accomplish, DateTime date)
        {
            EventId = eventId;
            CongregationId = congregationId;
            OrganistId = organistId;
            Accomplish = accomplish;
            Date = date;
        }

        public int Id { get; set; }
        public int EventId { get; set; }
        public virtual EventModel Event { get; set; }
        public int CongregationId { get; set; }
        public virtual CongregationModel Congregation { get; set; }
        public int OrganistId { get; set; }
        public virtual OrganistModel Organist { get; set; }
        public EAccomplish Accomplish { get; set; }
        public DateTime Date { get; set; }
    }
}
