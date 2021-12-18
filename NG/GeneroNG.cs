using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace NG
{
    public partial class BibliotecaNG : BibliotecaServiceNG
    {
        public List<Genero> SelectTodosGeneros(string connectionString, AD.BibliotecaServiceAD serviceAD)
        {
            List<Genero> listaGeneros = new List<Genero>();

            try
            {
                DataTable dt = serviceAD.SelectTodosGeneros(connectionString);

                foreach (DataRow row in dt.Rows)
                {
                    Genero genero = new Genero()
                    {
                        id = Convert.ToInt32(row["idGenero"]),
                        nome = row["nome"].ToString(),
                    };

                    listaGeneros.Add(genero);
                }
                return listaGeneros;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Genero SelectGeneroPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                DataRow row = serviceAD.SelectGeneroPorID(connectionString, id).Rows[0];

                Genero genero = new Genero()
                {
                    id = Convert.ToInt32(row["idGenero"]),
                    nome = row["nome"].ToString(),
                };
                
                return genero;
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
 
        public int DeleteGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                return serviceAD.DeleteGenero(connectionString, id);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

        public int InsertGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, Genero genero)
        {
            try
            {
                return serviceAD.InsertGenero(connectionString, genero);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public int UpdateGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, Genero genero)
        {
            try
            {
                return serviceAD.UpdateGenero(connectionString, genero);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
