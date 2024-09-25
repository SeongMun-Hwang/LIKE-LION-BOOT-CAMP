using System;
using static System.Console;

namespace Program
{
    class MainApp
    {
        class Book
        {
            public string name;
            public string author;
            public bool isBorrowed;
            public Book(string name, string author, bool isBorrowed)
            {
                this.name = name;
                this.author = author;
                this.isBorrowed = isBorrowed;
            }
        }
        class Library
        {
            private List<Book> books;

            public void AddBook(Book book)
            {
                if (books == null)
                {
                    books = new List<Book>();
                }
                books.Add(book);
            }
            public void SearchBookbyAuthor(string author)
            {
                WriteLine("Choose Option : 1. All  2. Non-borrowed");
                string option;
                option = ReadLine();

                bool removeBorrowed = false;
                if (option == "2") { removeBorrowed = true; }

                foreach(Book book in books)
                {
                    if (removeBorrowed)
                    {
                        if (book.author == author && !book.isBorrowed)
                        {
                            WriteLine("Book name : " + book.name + " isBorrowed : " + book.isBorrowed);
                        }
                    }
                    else
                    {
                        if (book.author == author)
                        {
                            WriteLine("Book name : " + book.name + " isBorrowed : " + book.isBorrowed);
                        }
                    }
                }
            }
        }

        //#4
        static void Main(string[] args)
        {
            Library library = new Library();
            library.AddBook(new Book("Abc", "Kim", false));
            library.AddBook(new Book("Def", "Kim", false));
            library.AddBook(new Book("Dog", "Lee", true));
            library.AddBook(new Book("Cat", "Lee", false));
            library.AddBook(new Book("Memory", "Hun", false));

            string author;
            WriteLine("Input Author name : ");
            author = ReadLine();
            library.SearchBookbyAuthor(author);
        }
    }
}