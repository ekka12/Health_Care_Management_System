namespace BLL;
using BOL;
using DAL;

public class MedicalManager{
 
  public User AllPatient(string uname,string password){
     CollectionContext ctx = new CollectionContext();
     var pobj = ctx.User.FirstOrDefault(pt=>pt.Username.Equals(uname)) ;
     return pobj;
  }

  public List<ProblemRequest> ShowAllProblems(){
     CollectionContext ctx = new CollectionContext();
     var plist = from pr in ctx.ProblemRequest select pr;
     return plist.ToList<ProblemRequest>();
  }

  public List<ProblemResponse> ShowAllSolutions(){
     CollectionContext ctx = new CollectionContext();
     var slist = from so in ctx.ProblemResponse select so;
     return slist.ToList<ProblemResponse>();
  }

}
