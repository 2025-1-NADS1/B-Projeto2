
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace DumpHttpRequests
{
    internal class Program
    {
        private static void Main(string[] args)
        {
           
            // lista de prefixos de URI,
            var prefixes = new List<string>() { "http://localhost:9999/" };

            // Cria um "OUVIDOR" (servidor) HTTP
            HttpListener listener = new HttpListener();
            // Adiciona os prefixos que o Servidor deve responder.
            foreach (string s in prefixes)
            {
                listener.Prefixes.Add(s);
            }
            listener.Start();
            Console.WriteLine("Ouvindo...");
            while (true)
            {
                // Interrompe execução e aguarda uma chamada HTTP
                HttpListenerContext context = listener.GetContext();
                //Recupera os dadaos da CHAMADA
                HttpListenerRequest request = context.Request;

                // Recupera paramêtros do request quando dor o caso
                string documentContents;
                using (Stream receiveStream = request.InputStream)
                {
                    using (StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8))
                    {
                        documentContents = readStream.ReadToEnd();
                    }
                }

                //Análisa o request
                Console.WriteLine("URL Completa " + request.Url);
                Console.WriteLine("Extensão da URL " + request.RawUrl);

                NameValueCollection qs = request.QueryString;

                for (int i = 0; i < qs.Count; i++)
                {
                    Console.WriteLine("Query String " + qs[i]);
                }

                if (!String.IsNullOrEmpty(qs["x"]))
                {
                    Console.WriteLine("x="+qs["x"]);
                }


                // Obtem o canal de reposta.
                HttpListenerResponse response = context.Response;
                // Constroi a resposta
                string responseString = "<HTML><BODY> RESPOSTA DA CHAMADA !!!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                // Envia resposta
                response.ContentLength64 = buffer.Length;
                System.IO.Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // Fecha camal de resposta.
                output.Close();
            }
            listener.Stop();
        }
    }
}