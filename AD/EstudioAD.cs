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
        public DataTable SelectTodosEstudios(string connectionString)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from Estudio order by nome";
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

        public DataTable SelectEstudioPorID(string connectionString, int id)
        {
            DataTable dt = new DataTable();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "select * from Estudio where idEstudio = @idEstudio";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idEstudio", id);
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

        public int DeleteEstudio(string connectionString, int id)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "delete from Estudio where idEstudio = @idEstudio";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@idEstudio", id);
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

        public int InsertEstudio(string connectionString, Estudio estudio)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "insert into Estudio(nome) values (@nome)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", estudio.nome);
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

        public int UpdateEstudio(string connectionString, Estudio estudio)
        {
            int rowsAffected = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    Console.WriteLine("Conexão Aberta");

                    string query = "update Estudio set nome = @nome where idEstudio = @idEstudio";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome", estudio.nome);
                        cmd.Parameters.AddWithValue("@idJogo", estudio.idEstudio);

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
