using System.ComponentModel.DataAnnotations;

namespace AvoidDoS.XSS
{
    public class TestModel
    {
        [Required]
        // Almost always length of scripts become longer than 100
        // Use model validation to restrict input to expected formats

        [StringLength(100,ErrorMessage ="Input too long")]
        public string  UserName { get; set; }

        //@HTML.Raw() which takes input to server raw,if malicous user tries to send script code to our server, code will be able to perform something, because html is able process input, without worrying about it.
        // To avoid this, we don't have to use @HTML.Raw() in our form, so html will treat input as a text and server doing nothing with this malicious input :)
    }
}
