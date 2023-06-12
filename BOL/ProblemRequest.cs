namespace BOL;
using System.ComponentModel.DataAnnotations;

 public class  ProblemRequest {
     
      public int Id{get;set;}  
      public string? Problem{get;set;}
      [Key]
      public int pbkey{get;set;}
}
