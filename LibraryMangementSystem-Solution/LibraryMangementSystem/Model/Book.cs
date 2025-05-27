using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    //create a book class 
    public class Book
    {
        //assign the isbn in  string to give a unique id for each book
        public string ISBN { get; set; }
        //assign the Title in string datatype to give the title to respective book
        public string Title { get; set; }
        //assign the Author in string datatype to give the name of author
        public string Author { get; set; }
        //assign the publish in datetime datatype to giv ethe 
        public DateTime PublishedDate { get; set; }
       
        //override the default method to rturn book class details in the formated string
        public override string ToString()
        {
            return $"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Published: {PublishedDate:yyyy-MM-dd}";
        }
    }
}


