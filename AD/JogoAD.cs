using Model;
using Npgsql;
using System;
using System.Data;

namespace AD
{
    public partial class BibliotecaAD : BibliotecaServiceAD
    {
        public DataTable SelectTodosJogos(string connectionString)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "select * from jogo";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();
                    }
                }
                
                conn.Close();
                Console.WriteLine("Conexão Fechada");
                return dt;
            }
        }

        public DataTable SelectJogoPorID(string connectionString, int id)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "select * from jogo where idJogo = @idJogo";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();
                    }
                }
                
                conn.Close();
                Console.WriteLine("Conexão Fechada");
            }
            return dt;
        }

        public DataTable SelectJogoPorNome(string connectionString, string nome)
        {

            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {

                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "select * from jogo where nome = '%@nome%'";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", nome);
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        reader.Close();
                    }
                }

                conn.Close();
                Console.WriteLine("Conexão Fechada");
            }

            return dt;
        }

        public int DeleteJogo(string connectionString, int id)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "delete from jogo where idJogo = @idJogo";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idJogo", id);
                    rowsAffected = cmd.ExecuteNonQuery();
                }
                conn.Close();
                Console.WriteLine("Conexão Fechada");
            }

            return rowsAffected;
        }

        public int InsertJogo(string connectionString, Jogo jogo)
        {
            int idJogo = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "insert into jogo(nome, dataCompra, precoCompra, idEstudio) values (@nome, @dataCompra, @precoCompra, @idEstudio) returning idJogo";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", jogo.nome);
                    cmd.Parameters.AddWithValue("@dataCompra", jogo.dataCompra);
                    cmd.Parameters.AddWithValue("@precoCompra", jogo.precoCompra);
                    cmd.Parameters.AddWithValue("@idEstudio", (object)jogo.idEstudio ?? DBNull.Value);
                    idJogo = (int) cmd.ExecuteScalar();
                }
 
                conn.Close();
                Console.WriteLine("Conexão Fechada");
            }

            return idJogo;
        }

        public int UpdateJogo(string connectionString, Jogo jogo)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                Console.WriteLine("Conexão Aberta");

                string query = "update jogo set nome = @nome, dataCompra = @dataCompra, precoCompra = @precoCompra, idEstudio = @idEstudio where idJogo = @idJogo";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nome", jogo.nome);
                    cmd.Parameters.AddWithValue("@dataCompra", jogo.dataCompra);
                    cmd.Parameters.AddWithValue("@precoCompra", jogo.precoCompra);
                    cmd.Parameters.AddWithValue("@idEstudio", (object)jogo.idEstudio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@idJogo", jogo.idJogo);

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                conn.Close();
                Console.WriteLine("Conexão Fechada");

            }
            return rowsAffected;
        }
    }
}