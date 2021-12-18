using Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;

namespace NG
{
    public partial class BibliotecaNG : BibliotecaServiceNG
    {
        public List<Jogo> SelectTotosJogos(string connectionString, AD.BibliotecaServiceAD serviceAD)
        {
            List<Jogo> listaJogos = new List<Jogo>();

            try
            {
                DataTable dt = serviceAD.SelectTodosJogos(connectionString);

                foreach (DataRow row in dt.Rows)
                {
                    Jogo jogo = new Jogo()
                    {
                        idJogo = Convert.ToInt32(row["idJogo"]),
                        nome = row["nome"].ToString(),
                        dataCompra = Convert.ToDateTime(row["dataCompra"]),
                        precoCompra = Convert.ToDecimal(row["precoCompra"]),
                        idEstudio = row["idEstudio"] is DBNull ? null : Convert.ToInt32(row["idEstudio"])
                    };

                    listaJogos.Add(jogo);
                }
                return listaJogos;
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

        public Jogo SelectJogoPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                DataRow row = serviceAD.SelectJogoPorID(connectionString, id).Rows[0];

                Jogo jogo = new Jogo()
                {
                    idJogo = Convert.ToInt32(row["idJogo"]),
                    nome = row["nome"].ToString(),
                    dataCompra = Convert.ToDateTime(row["dataCompra"]),
                    precoCompra = Convert.ToDecimal(row["precoCompra"]),
                    idEstudio = row["idEstudio"] is DBNull? null : Convert.ToInt32(row["idEstudio"])
                };

                return jogo;

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

        public List<Jogo> ProcurarJogoPorNome(string connectionString, AD.BibliotecaServiceAD serviceAD, string nome)
        {
            List<Jogo> listaJogos = new List<Jogo>();

            try
            {
                DataTable dt = serviceAD.SelectJogoPorNome(connectionString, nome);

                foreach (DataRow row in dt.Rows)
                {
                    Jogo jogo = new Jogo()
                    {
                        idJogo = Convert.ToInt32(row["idJogo"]),
                        nome = row["nome"].ToString(),
                        dataCompra = Convert.ToDateTime(row["dataCompra"]),
                        precoCompra = Convert.ToDecimal(row["precoCompra"]),
                        idEstudio = row["idEstudio"] is DBNull ? null : Convert.ToInt32(row["idEstudio"])
                    };

                    listaJogos.Add(jogo);
                }
                return listaJogos;
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

        public int DeleteJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, int id)
        {
            try
            {
                return serviceAD.DeleteJogo(connectionString, id);
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

        public int InsertJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, Jogo jogo)
        {
            try
            {
                return serviceAD.InsertJogo(connectionString, jogo);
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public int UpdateJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, Jogo jogo)
        {
            try
            {
                return serviceAD.UpdateJogo(connectionString, jogo);
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
