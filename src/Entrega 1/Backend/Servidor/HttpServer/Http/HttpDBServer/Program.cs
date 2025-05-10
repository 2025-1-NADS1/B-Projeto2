using System;
using System.Net;
using System.Data.SQLite;
using System.Collections.Specialized;

static class Program
{
    static void Main()
    {
        CriarBancoDeDados();
        ListarDados(); // Só pra teste, depois pode remover
        Servidor();
    }

    static void Servidor()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:9999/");
        listener.Start();
        Console.WriteLine("Ouvindo...");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            if (request.HttpMethod == "GET")
            {
                if (request.Url.AbsolutePath == "/endpoint1")
                {
                    string resposta = "Você chamou o endpoint1!";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resposta);
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
                else if (request.Url.AbsolutePath == "/endpoint2")
                {
                    string resposta = "Você chamou o endpoint2!";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resposta);
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
                else if (request.Url.AbsolutePath == "/")
                {
                    string resposta = "Página Default";
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resposta);
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
                else if (request.Url.AbsolutePath == "/inserir")
                {
                    try
                    {
                        NameValueCollection qs = request.QueryString;
                        int Id = Convert.ToInt32(qs["id"]);
                        string Nome = qs["nome"];
                        InserirRegistro(Id, Nome);
                        string resposta = "Registro Inserido com sucesso.";
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resposta);
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    catch (Exception ex)
                    {
                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes("Erro ao inserir: " + ex.Message);
                        response.OutputStream.Write(buffer, 0, buffer.Length);
                    }
                    response.Close();
                }
                else if (request.Url.AbsolutePath == "/recuperar")
                {
                    NameValueCollection qs = request.QueryString;
                    int Id = Convert.ToInt32(qs["id"]);
                    string Nome = SelecionarNomePorId(Id);
                    string resposta = "Registro Recuperado! NOME: " + Nome;
                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(resposta);
                    response.OutputStream.Write(buffer, 0, buffer.Length);
                    response.Close();
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Close();
                }
            }
        }
    }

    #region BANCO DE DADOS

    static void CriarBancoDeDados()
    {
        if (!System.IO.File.Exists("exemplo.db"))
        {
            SQLiteConnection.CreateFile("exemplo.db");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
            {
                conn.Open();
                string sql = "CREATE TABLE exemplo (ID INT PRIMARY KEY NOT NULL, Nome TEXT NOT NULL)";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
    }

    static void InserirRegistro(int id, string nome)
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
        {
            conn.Open();
            string sql = "INSERT OR REPLACE INTO exemplo (ID, Nome) VALUES (@id, @nome)";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }

    static string SelecionarNomePorId(int id)
    {
        string nome = "";

        using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
        {
            conn.Open();
            string sql = "SELECT Nome FROM exemplo WHERE ID = @id";
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nome = reader.GetString(0);
                    }
                    else
                    {
                        nome = "Não encontrado";
                    }
                }
            }
            conn.Close();
        }

        return nome;
    }

    static void ListarDados()
    {
        using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db"))
        {
            conn.Open();
            string sql = "SELECT * FROM exemplo";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("Dados no banco:");
            while (reader.Read())
            {
                Console.WriteLine("ID: " + reader["ID"] + " | Nome: " + reader["Nome"]);
            }

            conn.Close();
        }
    }

    #endregion
}
