using System.Collections.Generic;

namespace MindHypertrophy.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //many-to-many mapper
        public ICollection<CardTag> CardTags { get; set; }

        //constructor (temp hack for EF)
        public Tag()
        {
            CardTags = new List<CardTag>();
        }
    }
}
