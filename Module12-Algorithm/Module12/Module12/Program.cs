namespace Module12
{
    static class Program
    {
        static void Main(string[] args)
        {
            var users = new List<User>();
            users.Add(new User { Name = "Татьяна", IsPremium = true });
            users.Add(new User { Name = "Виктор", IsPremium = true });
            users.Add(new User { Name = "Екатерина", IsPremium = false });
            users.Add(new User { Name = "Ольга", IsPremium = true });

            foreach (var user in users)
            {
                Console.WriteLine($"Здравствуйте, {user.Name}!");
                if (!user.IsPremium)
                {
                    ShowAds();
                }
            }

            Console.ReadLine();
        }

        private static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");            
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");            
            Thread.Sleep(3000);
        }
    }

}