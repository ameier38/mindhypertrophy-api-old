using System.Collections.Generic;

namespace MindHypertrophy.Models
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string CreatedDate { get; set; }
        public List<TagDTO> Tags { get; set; }
    }
}
