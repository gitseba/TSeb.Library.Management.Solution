using TSeb.Library.Core.Models;
using TSeb.Library.Data.Context;

namespace TSeb.Library.Management.ConsoleApp
{
    /// <summary>
    /// Se doreste implementarea unui sistem de management pentru o biblioteca, asftel incat cititorii sa poata imprumuta carti.
    /// Sistemul trebuie sa tina atat evidenta cartilor aflate in biblioteca, cat si a celor care au fost imprumutate. 
    /// 
    /// O carte imprumutata poate fi inapoiata in maximum 2 saptamani, in caz contrar, se plateste penalitate 
    /// pentru fiecare zi de intarziere (1% din valoarea pretului de inchiriere / zi intarziata). 
    /// 
    /// Cerinte: 
    /// - Se poate adauga o noua carte in biblioteca
    /// - Putem avea mai multe exemplare ale aceleasi carti
    /// - In momentul adaugarii unei noi carti, trebuie sa stim cel putin urmatoarele informatii:
    ///     - Numele cartii
    ///     - ISBN-ul 
    ///     - Pretul de inchiriere
    ///     
    /// - Se poate cere o lista cu toate cartile din biblioteca
    /// - Se poate afla numarul de exemplare disponibile pentru a numita carte
    /// - Se poate imprumuta si restitui o carte
    /// 
    /// Cerinte tehnice 
    ///     - Implementarea se va realiza folosind un Console Application, toate datele fiind stocate in memorie, nefiind nevoie de stocarea permanenta nicaieri
    ///     - Respectarea principiilor OOP 
    ///     - Scrierea unui cod cat mai curat si usor de inteles
    ///     - Stabilirea cazurilor critice de business ale problemei, pentru care sa se creeze Unit Tests
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSelect Option by pressing the desired number:\n" +
                "1. Get all the Books available in the library.\n" +
                "2. Add NEW book in the library.\n" +
                "3. Add EXISTING book in the library.\n" +
                "4. Rent a book from library.\n");
                if (MockedDataContext.RentalItems.Any())
                {
                    Console.WriteLine("5. Return rented book.");
                }
                Console.ForegroundColor = ConsoleColor.White;

                // Read user option
                var option = Console.ReadLine();
                if (option == "exit")
                {
                    return;
                }


                switch (option)
                {
                    case "1": // Se poate cere o lista cu toate cartile din biblioteca 
                        Console.WriteLine("Get all BOOKS -> ");
                        AppLogic.GetBooks();
                        break;

                    case "2": // Se poate adauga o noua carte in biblioteca
                        Console.WriteLine("Add new BOOK -> ");
                        var result = AppLogic.AddBook(new TrackItemModel<BookModel>
                        {
                            Id = MockedDataContext.Books.Count + 1,
                            StockQuantity = 5,
                            TrackingItem = new BookModel
                            {
                                Id = MockedDataContext.Books.Count + 1,
                                Title = "It Starts with Us: A Novel (2) (It Ends with Us)",
                                Authors = new string[] { "Colleen Hoover" },
                                ISBN = "978-1668001226"
                            }
                        });
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(result);
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case "3": // Putem avea mai multe exemplare ale aceleasi carti
                        Console.WriteLine("Update existing BOOK -> ");
                        AppLogic.UpdateBook(new TrackItemModel<BookModel>
                        {
                            Id = 1,
                            StockQuantity = 10,
                            TrackingItem = new BookModel
                            {
                                Id = 1,
                                Title = "The 50th Law",
                                Authors = new string[] { "50 Cent", "Robert Greene" },
                                ISBN = "979-8367220841"
                            }
                        });
                        break;

                    case "4":  // Se poate imprumuta o carte
                        Console.WriteLine("Rent a BOOK -> ");
                        AppLogic.RentBook(new RentalModel
                        {
                            RentalId = 1,
                            RenterName = "Sebs",
                            TaxCharge = 10,
                            RentDate = DateTime.Parse(DateTime.Now.ToString("g")),
                            Item = MockedDataContext.Books.FirstOrDefault()
                        });
                        break;

                    case "5":  // Se poate restitui o carte
                        Console.WriteLine("Return rented the BOOK -> ");
                        AppLogic.ReturnedBook(MockedDataContext.RentalItems.FirstOrDefault().RentalId);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(option), $"Not expected value: {option}");
                }
            }

            Console.ReadLine();
        }
    }
}