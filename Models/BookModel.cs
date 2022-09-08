namespace library_management.Models;

public class Book{
     public int bookid{get;set;}
     public string bookname{get;set;}
     public string bookauthor{get;set;}
     public int noofcopiesavailable{get;set;}
  public Book(int bookid,string bookname,string bookauthor,int noofcopiesavailable)
  {
    this.bookid=bookid;
    this.bookauthor=bookauthor;
    this.bookname=bookname;
    this.noofcopiesavailable=noofcopiesavailable;
  }


}

