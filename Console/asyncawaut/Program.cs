namespace asyncawaut
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Telechargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);


            //await downloadTask1;
            //await downloadTask2;
            await Task.WhenAll(downloadTask1, downloadTask2);
            Console.WriteLine("Fin du programme");

        }

        static async Task DownloadData(string url)
        {
            var httpclient = new HttpClient();
            //Console.Write("Telechargement...");

            //httpclient.GetStringAsync(url).Wait();
            //var task = httpclient.GetStringAsync(url);
            //task.Wait();
            var resultat = await httpclient.GetStringAsync(url);

            Console.WriteLine("OK -> "+url);
            //Console.WriteLine(task.Result);
            //Console.WriteLine(resultat);
        }

        static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}