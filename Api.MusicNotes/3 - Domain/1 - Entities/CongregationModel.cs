using Api.MusicNotes._3___Domain._2___Enum_s;
using System.Diagnostics;

namespace Api.MusicNotes._3___Domain._1___Entities
{
    public class CongregationModel
    {
        public CongregationModel(){}

        public CongregationModel(string name, string description, ESector sector)
        {
            Name = name;
            Description = description;
            Sector = sector;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ESector Sector { get; set; }
    }
}
