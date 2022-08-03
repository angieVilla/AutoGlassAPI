using System.ComponentModel.DataAnnotations;
public class Supplier{

    [Key]
    public Guid Id {get;set;}
    [Required]
    public int Code {get;set;}
    [Required]
    public string Description {get;set;}
    [Required]
    public string PhoneNumber {get;set;}

}