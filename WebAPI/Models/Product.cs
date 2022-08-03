using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public Guid Id {get;set;}
    [Required]
    public int Code {get;set;}
    [Required]
    public string Description {get;set;}
    public bool State {get;set;}    
    public DateTime ManufacturingDate {get;set;}    
    public DateTime ValidityDate {get;set;}
    public Guid SupplierId {get;set;}
    public virtual Supplier Supplier {get; set;}

}