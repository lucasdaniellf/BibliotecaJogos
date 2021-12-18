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
        public List<JogoGenero> SelectJogoGenerosPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            List<JogoGenero> listaJogoGenero = new List<JogoGenero>();
            try
            {
                DataTable dt = serviceAD.SelectJogoGeneroPorJogoId(connectionString, id);

                foreach (DataRow row in dt.Rows)
                {
                    JogoGenero jogoGenero = new JogoGenero()
                    {
                        idJogo = Convert.ToInt32(row["idJogo"]),
                        idGenero = Convert.ToInt32(row["idGenero"])
                    };

                    listaJogoGenero.Add(jogoGenero);
                }
                return listaJogoGenero;
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

        public List<JogoGenero> SelectJogoGenerosPorGeneroId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            List<JogoGenero> listaJogoGenero = new List<JogoGenero>();
            try
            {
                DataTable dt = serviceAD.SelectJogoGeneroPorGeneroId(connectionString, id);

                foreach (DataRow row in dt.Rows)
                {
                    JogoGenero jogoGenero = new JogoGenero()
                    {
                        idJogo = Convert.ToInt32(row["idJogo"]),
                        idGenero = Convert.ToInt32(row["idGenero"])
                    };

                    listaJogoGenero.Add(jogoGenero);
                }
                return listaJogoGenero;
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
        public int DeleteJogoGeneroPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                return serviceAD.DeleteJogoGeneroPorJogoId(connectionString, id);
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

        public int InsertJogoGeneroPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, JogoGenero jogoGenero)
        {
            try
            {
                return serviceAD.InsertJogoGenero(connectionString, jogoGenero);
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
