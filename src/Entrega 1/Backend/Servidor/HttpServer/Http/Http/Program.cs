
public class HttpCliente1 { 
    static readonly HttpClient client = new HttpClient();

    static async Task Main()
    {
    
        try
        {
            client.Timeout = TimeSpan.FromSeconds(10);
             string responseBody = await client.GetStringAsync("http://localhost:9999/");
            //string responseBody = await client.GetStringAsync("http://www.uol.com.br");
            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nFalha de Comunicação");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        Console.ReadLine();
    }
}