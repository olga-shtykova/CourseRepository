using System;

namespace Module7
{
    class Program
    {
        public static void Main(string[] args)
        {
            var array = new BookClass[] {
            new BookClass { Name = "Мастер и Маргарита", Author = "М.А. Булгаков" },
            new BookClass { Name = "Отцы и дети", Author = "И.С. Тургенев" },
        };
            BookCollection collection = new BookCollection(array);

            BookClass book = collection[1];
            Console.WriteLine(book.Name);
            book = collection["Мастер и Маргарита"];
            Console.WriteLine(book.Name);

            //SmartHelper helper = new SmartHelper("Олег");
            //helper.Greetings("Грег");

            //DerivedClass obj = new DerivedClass();
            //obj.Display();

            //D d = new D();
            //E e = new E();

            //d.Display();
            //((A)e).Display();
            //((B)d).Display();
            //((A)d).Display();

            Console.ReadKey();
        }
    }
}
