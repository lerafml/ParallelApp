using System.Diagnostics;

namespace ParallelApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            CountSpacesInFiles("C:\\Users\\necra\\OneDrive\\Рабочий стол\\test");
            timer.Stop();
            Console.WriteLine($"Время выполнения в мс: {timer.Elapsed.TotalMilliseconds}");
        }

        public static void CountSpacesInFiles(string path)
        {
            List<Task> tasks = new List<Task>();
            foreach(var file in Directory.GetFiles(path))
            {
                tasks.Add(Task.Run(() => DoCount(file)));
            }
            Task.WaitAll(tasks.ToArray());
        }

        public static void DoCount(string file)
        {
            string text = File.ReadAllText(file);
            int count = 0;
            foreach(char c in text)
            {
                if (c == ' ')
                    count++;
            }
            Console.WriteLine($"Количество пробелов: {count} в файле: {file}");
        }
    }
}
