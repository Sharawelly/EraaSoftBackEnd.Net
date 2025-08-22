namespace task3part2
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author, string iSBN, bool isAvailable = true)
        {
            Title = title;
            Author = author;
            ISBN = iSBN;
            IsAvailable = isAvailable;
        }
    }


    class LibraryManagementSystem
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public (bool found, int index) SearchForBookByAuthor(string author)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author == author)
                {
                    return (true, i); 
                }
            }
            return (false, -1); 
        }


        public (bool found, int index) SearchForBookByTitle(string title)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Title != null && books[i].Title.Contains(title))
                {
                    return (true, i);
                }
            }
            return (false, -1); 
        }


        public void findBookIfExistAndBorrowItOrReturnIt(String title, bool isAvailable)
        {
            var result = SearchForBookByTitle(title);
            if (result.found)
            {
                books[result.index].IsAvailable = isAvailable;
            }
            else
            {
                System.Console.WriteLine($"The Book with title {title} not {(isAvailable ? "borrowed" : "found")}");
            }
        }



        public void BorrowBook(String title)
        {
            findBookIfExistAndBorrowItOrReturnIt(title, false);


        }

        public void ReturnBook(String title)
        {
            findBookIfExistAndBorrowItOrReturnIt(title, true);


        }
        internal class Program
        {
            static void Main(string[] args)
            {
                LibraryManagementSystem library = new LibraryManagementSystem();

                // Adding books to the library
                library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
                library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
                library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

                Console.WriteLine("Searching and borrowing books...");
                library.BorrowBook("Gatsby");
                library.BorrowBook("1984");
                library.BorrowBook("Harry Potter"); // This book is not in the library

                // Returning books
                Console.WriteLine("\nReturning books...");
                library.ReturnBook("Gatsby");
                library.ReturnBook("Harry Potter"); // This book is not borrowed


            }
        }
    }
}