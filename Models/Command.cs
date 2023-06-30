using System.ComponentModel.DataAnnotations;

namespace CommandHelper.Models
{
    public class Command{

        [Key]
        public int ID { get; set; }

        [Required][MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }
        
        [Required]
        public string Platform { get; set; }        

    }
}


