using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._2___Application._2___DTO_s.Organist
{
    public class OrganistInsert
    {
        public string Name { get; set; }
        public int CongregationId { get; set; }
        public ESituation Situation { get; set; }
        public bool Christening { get; set; }
        public EMaritalStatus MaritalStatus { get; set; }
    }
}
