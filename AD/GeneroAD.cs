using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AD
{
    public partial class BibliotecaAD : BibliotecaServiceAD
    {
        public DataTable SelectTodosGeneros(string connectionString)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from Genero order by nome";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (NpgsqlException)
                {
                    throw;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Conexão Fechada");
                }
            }

            return dt;
        }

        public DataTable SelectGeneroPorID(string connectionString, int id)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from Genero where idGenero = @idGenero";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                        }
                    }
                }

                catch (NpgsqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Conexão Fechada");
                }
            }

            return dt;
        }

        public int DeleteGenero(string connectionString, int id)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "delete from genero where idGenero = @idGenero";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", id);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                catch (NpgsqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Conexão Fechada");
                }
            }

            return rowsAffected;
        }

        public int InsertGenero(string connectionString, Genero genero)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "insert into Genero(nome) values (@nome)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", genero.nome);
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                catch (NpgsqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Conexão Fechada");
                }
            }
            return rowsAffected;
        }

        public int UpdateGenero(string connectionString, Genero genero)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "update genero set nome = @nome where idGenero = @idGenero";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", genero.nome);
                        cmd.Parameters.AddWithValue("@idJogo", genero.id);

                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }

                catch (NpgsqlException)
                {
                    throw;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Conexão Fechada");
                }
            }
            return rowsAffected;
        }
    }
}
