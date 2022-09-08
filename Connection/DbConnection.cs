using System.Data.SqlClient;
public sealed class Database{
     private static volatile SqlConnection con;
     private static object lock1=new object();
     private const String connectionstring="Server=localhost\\SQLEXPRESS;database=library;Integrated Security=false;";
     
     private Database(){

     }
     public static SqlConnection Con{
        get{
            if(con==null) 
            {
                lock(lock1)
                {
                    if(con==null)
                      con=new SqlConnection(connectionstring);
                }
            }
            return con;

        }
     }
}