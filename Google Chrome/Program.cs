using System.Net.Http;

namespace Google_Chrome
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Chrome chrome = new Chrome();

                bool running = true;
                string? uri = "";

                while (running)
                {
                    while (uri == "")
                    {
                        Console.Write("Adress: ");
                        uri = Console.ReadLine();

                        if (uri == "exit")
                        {
                            running = false;
                            return;
                        }
                    }

                    Console.WriteLine(await chrome.GetWebsite(uri!)!);

                    uri = "";

                    Console.ReadKey();
                    Console.Clear();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}