using System.ComponentModel.DataAnnotations;

namespace BlazorStaticSSR.Model;

public class Message
{
    [Required, MinLength(3), MaxLength(20)]
    public string Subject { get; set; }
    [Required]
    public string Content { get; set; }
}
