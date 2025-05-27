using LibraryMangementSystem.Repo.LibraryManagementSystem;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> books = new Dictionary<string, Book>();
        private static Random rand = new Random(); // Avoid creating multiple instances

        /// <summary>
       ///condition  to display if there no book in library
        /// </summary>
        public void ListAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available in the library.");
                return;
            }

            foreach (var book in books.Values)
            {
                Console.WriteLine(book);
            }
        }
        //to add a new book in the dictionary 
        public void AddBook(Book book)
        {
            if (books.ContainsKey(book.ISBN))
            {
                Console.WriteLine("A book with this ISBN already exists.");
                return;
            }

            books.Add(book.ISBN, book);
            Console.WriteLine($"\n✅ Book added successfully. ISBN: {book.ISBN}\n");
        }

        //to edit the title of the book
        public void EditBook(string isbn)
        {
            if (!books.ContainsKey(isbn))
            {
                Console.WriteLine("Book not found.");
                return;
            }

            Book book = books[isbn];

            Console.Write("Enter new Title: ");
            string title = Console.ReadLine();
            while (!Validation.IsValidText(title))
            {
                Console.Write("Invalid title. Enter again: ");
                title = Console.ReadLine();
            }

            Console.Write("Enter new Author: ");
            string author = Console.ReadLine();
            while (!Validation.IsValidText(author))
            {
                Console.Write("Invalid author name. Enter again: ");
                author = Console.ReadLine();
            }

            Console.Write("Enter new Published Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();
            DateTime pubDate;
            while (!Validation.IsValidPastDate(dateInput, out pubDate))
            {
                Console.Write("Invalid or future date. Enter again: ");
                dateInput = Console.ReadLine();
            }

            book.Title = title;
            book.Author = author;
            book.PublishedDate = pubDate;

            Console.WriteLine("✅ Book details updated successfully.");
        }

        // to remove the book from the library

        public void RemoveBook(string isbn)
        {
            if (books.Remove(isbn))
                Console.WriteLine("✅ Book removed successfully.");
            else
                Console.WriteLine("Book not found.");
        }
        //to search the book by author's name
        public void SearchByAuthor(string author)
        {
            SearchBooks(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase), "author");
        }
        //to search the book by the title
        public void SearchByTitle(string title)
        {
            SearchBooks(book => book.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0, "title");
        }
        //tpo search the book 
        private void SearchBooks(Func<Book, bool> predicate, string criteria)
        {
            bool found = false;
            foreach (var book in books.Values)
            {
                if (predicate(book))
                {
                    Console.WriteLine(book);
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine($"No books found matching the given {criteria}.");
        }
        //to  auto generate the isbn 

        public string GenerateUniqueISBN()
        {
            string isbn;
            do
            {
                isbn = rand.Next(1000, 100000).ToString(); // 4 to 5 digits
            } while (books.ContainsKey(isbn));
            return isbn;
        }
        //to get total counts of the book in library
        public int GetBookCount()
        {
            return books.Count;
        }
    }
}
