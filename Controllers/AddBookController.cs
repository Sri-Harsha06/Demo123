using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library_management.Models;
using System.Data.SqlClient;
namespace library_management.Controllers;

public class AddBookController:Controller{
     private readonly ILogger<AddBookController> _logger;

    public AddBookController(ILogger<AddBookController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddBook()
    {
        List<Book>ls1=new List<Book>();
        SqlConnection con=Database.Con;
        con.Open();
        String qry1="select * from books";
        SqlCommand cmd=new SqlCommand(qry1,con);
        System.Console.WriteLine("hii");
        SqlDataReader rd=cmd.ExecuteReader();
        while(rd.Read()){
            System.Console.WriteLine("{0}",rd[0]);
        //    var nb=new Book((int)rd[0],rd[1].ToString(),rd[2].ToString(),(int)rd[3]);
        //    ls1.Add(nb);
        }
        ViewData["Books"]=ls1;
        return View();
    }
}