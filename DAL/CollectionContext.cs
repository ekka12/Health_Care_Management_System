namespace DAL;
using BOL;
using Microsoft.EntityFrameworkCore;

public class CollectionContext : DbContext{
  
   public DbSet<User> User {get;set;}
   public DbSet<ProblemRequest> ProblemRequest {get;set;}
   public DbSet<ProblemResponse> ProblemResponse {get;set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        
        string url = @"server=localhost;user=root;password=hopefulldiku@12;database=kratins";
        optionsBuilder.UseMySQL(url);

    }
}
