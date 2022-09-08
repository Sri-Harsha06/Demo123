using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using library_management.Models;
using System.Data.SqlClient;
namespace library_management.Controllers;

public class AddBookController : Controller
{
    private readonly ILogger<AddBookController> _logger;

    public AddBookController(ILogger<AddBookController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        System.Console.WriteLine("hiii2222");
        List<Book> ls1 = new List<Book>();
        SqlConnection con = Database.Con;
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Book", con);
        System.Console.WriteLine("hii");
        SqlDataReader rd = cmd.ExecuteReader();
        while (rd.Read())
        {
            System.Console.WriteLine("{0}", rd[0]);
            ls1.Add(new Book { bookid = (int)rd[0], bookname = rd[1].ToString(), bookauthor = rd[2].ToString(), noofcopiesavailable = (int)rd[3] });
        }
        con.Close();
        return View(ls1);
    }

}