using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Demo123.Models;
namespace Demo123.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Addbook(Models.Book new_book)
    {
        // System.Console.WriteLine("hiii2222");
        // List<Book> ls1 = new List<Book>();
        // SqlConnection con = Database.Con;
        // con.Open();
        // SqlCommand cmd = new SqlCommand("select * from Book", con);
        // System.Console.WriteLine("hii");
        // SqlDataReader rd = cmd.ExecuteReader();
        // while (rd.Read())
        // {
        //     System.Console.WriteLine("{0}", rd[0]);
        //     ls1.Add(new Book { bookid = (int)rd[0], bookname = rd[1].ToString(), bookauthor = rd[2].ToString(), noofcopiesavailable = (int)rd[3] });
        // }
        // con.Close();
        ViewBag.id=new_book.bookid;
        ViewBag.name=new_book.bookname;
        return View("Index");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
