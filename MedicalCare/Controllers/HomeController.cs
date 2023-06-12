using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MedicalCare.Models;
using BOL;
using BLL;
namespace MedicalCare.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet]
    public IActionResult logout(){
        HttpContext.Session.Remove("username");
        HttpContext.Session.Remove("id");
        HttpContext.Session.Remove("gender");
        return RedirectToAction("index","home");
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
      public IActionResult Index(string uname,string password){
        MedicalManager mm = new MedicalManager();
        User user = mm.AllPatient(uname,password);
        Console.WriteLine("-----------"+user.Username+"---------"+user.Password);
        if(user.Username.Equals(uname)){
            if(user.Password.Equals(password)){
                HttpContext.Session.SetInt32("id",user.Id);
                HttpContext.Session.SetString("username",user.Username);
                HttpContext.Session.SetString("gender",user.Gender);
                return RedirectToAction("ClientPage","home");
            }
            else{
                
               TempData["message"] = "Invalid Credentials";
               return RedirectToAction("index","home");
            } 
        }
        return View();
    }

    [HttpGet]
    public IActionResult ClientPage(){
        var id = HttpContext.Session.GetInt32("id");
        var uname =HttpContext.Session.GetString("username");
        Console.WriteLine(uname+"------------------------------------->");
        if(uname==null){
            TempData["message"]="Please sign in first";
            return RedirectToAction("index","home");
        }else{
        var gender =HttpContext.Session.GetString("gender");
        Console.WriteLine(id+"--------"+uname+"---------->"+gender+"---------->}");
        
        ViewData["uname"]=uname;
        ViewData["gender"]=gender;

        MedicalManager mm = new MedicalManager();
        List<ProblemRequest>plist = mm.ShowAllProblems();
        if(plist!=null){
            ViewData["problems"] = plist;
        }
        
        
        return View();
        }
    }

    [HttpPost]
    public IActionResult ClientPage(int problem1, int problem2, int problem3, int problem4, int problem5, int problem6,int prob5id,int prob6id,string uname,string gender){
        
         TempData["problem1"] = problem1;
         TempData["problem2"] = problem2;
         TempData["problem3"] = problem3;
         TempData["problem4"] = problem4;
         TempData["problem5"] = prob5id;         
         if(problem5>=0 && problem5<=25){
            int updatevalue1 = 5;
            TempData["respid1"] = updatevalue1;
         }else if(problem5>=26 && problem5<=50){
            int updatevalue1 = 10;
            TempData["respid1"] = updatevalue1;
         }else if(problem5>=51 && problem5<=75){
            int updatevalue1 = 15;
            TempData["respid1"] = updatevalue1;
         }else if(problem5>=76 && problem5<=100){
            int updatevalue1 = 20;
            TempData["respid1"] = updatevalue1;
         }
        
         TempData["problem6"] = prob6id;
         if(problem6>=0 && problem6<=25){
            int updatevalue2 = 5;
            TempData["respid2"] = updatevalue2;
         }else if(problem6>=26 && problem6<=50){
            int updatevalue2 = 10;
            TempData["respid2"] = updatevalue2;
         }else if(problem6>=51 && problem6<=75){
            int updatevalue2 = 15;
            TempData["respid2"] = updatevalue2;
         }else if(problem6>=76 && problem6<=100){
            int updatevalue2 = 20;
            TempData["respid2"] = updatevalue2;
         }

         TempData["uname"]=uname;
         TempData["gender"]=gender;
         return RedirectToAction("ClientQueryResponse","home");
    }

    [HttpGet]
    public IActionResult ClientQueryResponse(){ 
        var uname =HttpContext.Session.GetString("username");
        Console.WriteLine(uname+"------------------------------------->");
        if(uname==null){
            TempData["message"]="Please sign in first";
            return RedirectToAction("index","home");
        }else{           
        MedicalManager mm = new MedicalManager();
        List<ProblemResponse> slist = mm.ShowAllSolutions();
        if(slist!=null){
             foreach(ProblemResponse pr in slist){
                Console.WriteLine(pr.Id+"----------------->");
             }
            ViewData["solutionforQuery"] = slist;
        }
        return View();
        }
    }


   
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
