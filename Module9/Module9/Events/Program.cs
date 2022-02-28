namespace Events
{
    class Program
    {
        static void Main(string[] args) 
        {
            ProcessBusinessLogic bl = new ProcessBusinessLogic();
            bl.ProcessCompleted += bl_ProcessCompleted; // регистрируем событие
            bl.StartProcess();
        }

        // перехватчик событий

        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Процесс завершён!");
        }

    }
}