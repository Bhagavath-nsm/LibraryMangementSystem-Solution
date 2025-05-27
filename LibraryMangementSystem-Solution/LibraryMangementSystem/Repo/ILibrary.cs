using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagementSystem;

namespace LibraryMangementSystem.Repo
{
    namespace LibraryManagementSystem
    {
        public interface ILibrary
        {
            //Display all the books available in library
            void ListAllBooks();
            //Add a NewBook
            void AddBook(Book book);
            //Edits an existing book based on ISBN.

            

            void EditBook(string isbn);
            //To Delete the book from the library
            void RemoveBook(string isbn);
            //To search the book by author
            void SearchByAuthor(string author);
            //To search the book by title
            void SearchByTitle(string title);

            //to autogenerate the isbn
            string GenerateUniqueISBN();
        }
    }
}
