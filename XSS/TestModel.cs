using System.ComponentModel.DataAnnotations;

namespace AvoidDoS.XSS
{
    public class TestModel
    {
        [Required]
        // Almost always length of scripts longer than 100
        // Use model validation to restrict input to expected formats

        [StringLength(100,ErrorMessage ="Input too long")]
        public string  UserName { get; set; }
    }
}
