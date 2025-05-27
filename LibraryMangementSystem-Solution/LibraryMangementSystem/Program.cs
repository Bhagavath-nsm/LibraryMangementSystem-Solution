using System;
using LibraryMangementSystem.Repo.LibraryManagementSystem;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            ILibrary library = new Library();

            while (true)
            {
                Console.WriteLine("\n--- Library Management System ---");
                Console.WriteLine("1. List All Books");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Edit Book");
                Console.WriteLine("4. Remove Book");
                Console.WriteLine("5. Search by Author");
                Console.WriteLine("6. Search by Title");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice (1-7): ");

                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            library.ListAllBooks();
                            break;
                        case 2:
                            Book book = GetbookDetails();
                            library.AddBook(book);
                            break;
                        case 3:
                            Console.Write("Enter the ISBN to edit: ");
                            string editIsbn = Console.ReadLine();
                            library.EditBook(editIsbn);
                            break;
                        case 4:
                            Console.Write("Enter the ISBN to remove: ");
                            string removeIsbn = Console.ReadLine();
                            library.RemoveBook(removeIsbn);
                            break;
                        case 5:
                            Console.Write("Enter the Author name: ");
                            string author = Console.ReadLine();
                            library.SearchByAuthor(author);
                            break;
                        case 6:
                            Console.Write("Enter the book title: ");
                            string title = Console.ReadLine();
                            library.SearchByTitle(title);
                            break;
                        case 7:
                            Console.WriteLine("Exiting the application...");
                            return;
                        default:
                            Console.WriteLine("Please select a valid option (1-7).");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Validation Error: " + ex.Message);
                }
            }
        }

        static Book GetbookDetails()
        {
            string isbn;
            do
            {
                Console.Write("Enter ISBN (4 or 5 digits): ");
                isbn = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(isbn) || !Validation.IsValidISBN(isbn))
                    Console.WriteLine("❌ Invalid ISBN format. Try again.");
                else
                    break;
            } while (true);

            string title;
            do
            {
                Console.Write("Enter Title: ");
                title = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(title) || !Validation.IsValidText(title))
                    Console.WriteLine("❌ Invalid title. Only letters, numbers, and spaces are allowed.");
                else
                    break;
            } while (true);

            string author;
            do
            {
                Console.Write("Enter Author: ");
                author = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(author) || !Validation.IsValidText(author))
                    Console.WriteLine("❌ Invalid author name. Only letters, numbers, and spaces are allowed.");
                else
                    break;
            } while (true);

            string dateInput;
            DateTime pubDate;
            do
            {
                Console.Write("Enter Published Date (yyyy-MM-dd): ");
                dateInput = Console.ReadLine()?.Trim();
                if (!Validation.IsValidPastDate(dateInput, out pubDate))
                    Console.WriteLine("❌ Invalid date or date cannot be in the future. Try again.");
                else
                    break;
            } while (true);

            return new Book
            {
                ISBN = isbn,
                Title = title,
                Author = author,
                PublishedDate = pubDate
            };
        }


    }
}
