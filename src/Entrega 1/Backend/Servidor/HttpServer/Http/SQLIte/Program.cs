using System.Runtime.Intrinsics.X86;
using System.Data.SQLite; // Importa a biblioteca SQLite



static void CriarBancoDeDados()
{
    SQLiteConnection.CreateFile("exemplo.db"); // Cria o arquivo do banco de dados

    using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
    {
        conn.Open(); // Abre a conexão com o banco de dados

        string sql = "CREATE TABLE exemplo (ID INT PRIMARY KEY NOT NULL, Nome TEXT NOT NULL)";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.ExecuteNonQuery(); // Executa o comando SQL para criar a tabela
        }

        conn.Close(); // Fecha a conexão com o banco de dados
    }
}


static void InserirRegistro(int id, string nome)
{
    using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
    {
        conn.Open(); // Abre a conexão com o banco de dados

        string sql = "INSERT INTO exemplo (ID, Nome) VALUES (@id, @nome)";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.ExecuteNonQuery(); // Executa o comando SQL para inserir o registro
        }

        conn.Close(); // Fecha a conexão com o banco de dados
    }
}



static void AlterarRegistro(int id, string novoNome)
{
    using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
    {
        conn.Open(); // Abre a conexão com o banco de dados

        string sql = "UPDATE exemplo SET Nome = @novoNome WHERE ID = @id";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@novoNome", novoNome);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery(); // Executa o comando SQL para alterar o registro
        }

        conn.Close(); // Fecha a conexão com o banco de dados
    }
}

static string SelecionarNomePorId(int id)
{
    string nome = "";

    using (SQLiteConnection conn = new SQLiteConnection("Data Source=exemplo.db;Version=3;"))
    {
        conn.Open(); // Abre a conexão com o banco de dados

        string sql = "SELECT Nome FROM exemplo WHERE ID = @id";
        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@id", id);
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    nome = reader.GetString(0); // Obtém o valor da coluna "Nome" do registro selecionado
                }
            }
        }

        conn.Close(); // Fecha a conexão com o banco de dados
    }

    return nome;
}

String Nome;
CriarBancoDeDados();
InserirRegistro(1, "TESTE");
Nome = SelecionarNomePorId(1);
Console.WriteLine("Nome Original: " + Nome);
AlterarRegistro(1, "TESTE3");
Nome = SelecionarNomePorId(1);
Console.WriteLine("Nome Alterado: " + Nome);


