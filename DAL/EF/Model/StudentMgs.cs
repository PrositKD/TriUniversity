using DAL.EF.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

public class StudentMgs
{
    [Key]
    public int MgsId { get; set; }

    [Required(ErrorMessage = "Student is required")]
    [ForeignKey("Student")]
    public int StudentId { get; set; }

    [Required(ErrorMessage = "Teacher is required")]
    [ForeignKey("Teacher")]
    public int TeacherId { get; set; }

    
   // public DateTime? DateOfMgs { get; set; }

    [Required(ErrorMessage = "Message is required")]
    public string Message { get; set; }

    public string Reply { get; set; }

    public DateTime? DateOfMgsReply { get; set; } // Nullable DateTime

    public virtual Student Student { get; set; }

    public virtual Teacher Teacher { get; set; }
}
