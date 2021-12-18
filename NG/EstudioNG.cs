using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace NG
{
    public partial class BibliotecaNG : BibliotecaServiceNG
    {
        public List<Estudio> SelectTodosEstudios(string connectionString, AD.BibliotecaServiceAD serviceAD)
        {
            List<Estudio> listaEstudios = new List<Estudio>();

            try
            {
                DataTable dt = serviceAD.SelectTodosEstudios(connectionString);

                foreach (DataRow row in dt.Rows)
                {
                    Estudio estudio = new Estudio()
                    {
                        idEstudio = Convert.ToInt32(row["idEstudio"]),
                        nome = row["nome"].ToString(),
                    };

                    listaEstudios.Add(estudio);
                }
                return listaEstudios;
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

        public Estudio SelectEstudioPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                DataRow row = serviceAD.SelectEstudioPorID(connectionString, id).Rows[0];

                Estudio estudio = new Estudio()
                {
                    idEstudio = Convert.ToInt32(row["idEstudio"]),
                    nome = row["nome"].ToString(),
                };

                return estudio;
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

        public int DeleteEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                return serviceAD.DeleteEstudio(connectionString, id);
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

        public int InsertEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, Estudio estudio)
        {
            try
            {
                return serviceAD.InsertEstudio(connectionString, estudio);
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

        public int UpdateEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, Estudio estudio)
        {
            try
            {
                return serviceAD.UpdateEstudio(connectionString, estudio);
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
