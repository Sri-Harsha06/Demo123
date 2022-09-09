using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Demo123.Models;
namespace Demo123.Controllers;
using System.Data.SqlClient;
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
        SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;database=library;Trusted_Connection=false;Integrated Security = true;");
        con.Open();
        string query="insert into books(BookName,BookAuthor,NoOfCopies) output inserted.bookid values(@bookname,@bookAuthor,@copiesAvailable) ";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.Parameters.AddWithValue("@bookName",new_book.bookname);
        cmd.Parameters.AddWithValue("@bookAuthor",new_book.bookauthor);
        cmd.Parameters.AddWithValue("@copiesAvailable",new_book.noofcopiesavailable);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("hii");
        // SqlDataReader rd = cmd.ExecuteReader();
        // while (rd.Read())
        // {
        //     System.Console.WriteLine("{0}", rd[0]);
        //     ls1.Add(new Book { bookid = (int)rd[0], bookname = rd[1].ToString(), bookauthor = rd[2].ToString(), noofcopiesavailable = (int)rd[3] });
        // }
        con.Close();
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
