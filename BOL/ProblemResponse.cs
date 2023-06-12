namespace BOL;
using System.ComponentModel.DataAnnotations;

public class ProblemResponse{   
    public int Id{get;set;}
    public string? Solution{get;set;}
    public int RespId{get;set;}
    [Key]
    public int RespKey{get;set;}
}