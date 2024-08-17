using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Domain.Entities;

public class Administrator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string ?Email { get; set; }
    
    [StringLength(50)]
    public string Password { get; set; }

    [StringLength(10)]
    public string Profile { get; set; }
}