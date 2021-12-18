using Model;
using Npgsql;
using System;
using System.Data;

namespace AD
{
    public partial class BibliotecaAD : BibliotecaServiceAD
    {
        public DataTable SelectJogoGeneroPorJogoId(string connectionString, int id)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from JogoGenero where idJogo = @idJogo";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJogo", id);
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

        public DataTable SelectJogoGeneroPorGeneroId(string connectionString, int id)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from JogoGenero where idGenero = @idGenero";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idGenero", id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            dt.Load(reader);
                            reader.Close();
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

        public int DeleteJogoGeneroPorJogoId(string connectionString, int id)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "delete from jogoGenero where idJogo = @idJogo";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJogo", id);
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

        public int InsertJogoGenero(string connectionString, JogoGenero jogoGenero)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "insert into jogoGenero(idJogo, idGenero) values (@idJogo, @idGenero)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idJogo", jogoGenero.idJogo);
                        cmd.Parameters.AddWithValue("@idGenero", jogoGenero.idGenero);
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
