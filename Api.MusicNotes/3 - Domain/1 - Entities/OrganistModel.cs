using Api.MusicNotes._3___Domain._2___Enum_s;

namespace Api.MusicNotes._3___Domain._1___Entities
{
    public class OrganistModel
    {
        public OrganistModel(string name, int congregationId, ESituation situation, bool christening, EMaritalStatus maritalStatus)
        {
            Name = name;
            CongregationId = congregationId;
            Situation = situation;
            Christening = christening;
            MaritalStatus = maritalStatus;
        }
        public OrganistModel(){}
        public int Id { get; set; }
        public string Name { get; set; }
        public int CongregationId { get; set; }
        public virtual CongregationModel Congregation { get; set; }
        public ESituation Situation { get; set; }
        public bool Christening { get; set; }
        public EMaritalStatus MaritalStatus { get; set; }
    }
}
   

    