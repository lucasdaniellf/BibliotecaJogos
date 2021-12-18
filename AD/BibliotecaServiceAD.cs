using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AD
{
    public interface BibliotecaServiceAD
    {
        public DataTable SelectTodosJogos(string connectionString);
        public DataTable SelectJogoPorID(string connectionString, int id);
        public DataTable SelectJogoPorNome(string connectionString, string nome);
        public int DeleteJogo(string connectionString, int id);
        public int InsertJogo(string connectionString, Jogo jogo);
        public int UpdateJogo(string connectionString, Jogo jogo);

        //--------------Generos-----------------------//
        public DataTable SelectTodosGeneros(string connectionString);
        public DataTable SelectGeneroPorID(string connectionString, int id);
        public int DeleteGenero(string connectionString, int id);
        public int InsertGenero(string connectionString, Genero genero);
        public int UpdateGenero(string connectionString, Genero genero);

        //--------------Estudios-----------------------//
        public DataTable SelectTodosEstudios(string connectionString);
        public DataTable SelectEstudioPorID(string connectionString, int id);
        public int DeleteEstudio(string connectionString, int id);
        public int InsertEstudio(string connectionString, Estudio estudio);
        public int UpdateEstudio(string connectionString, Estudio estudio);

        //--------------JogoGenero------------------------//
        public DataTable SelectJogoGeneroPorJogoId(string connectionString, int id);
        public DataTable SelectJogoGeneroPorGeneroId(string connectionString, int id);
        public int DeleteJogoGeneroPorJogoId(string connectionString, int id);
        public int InsertJogoGenero(string connectionString, JogoGenero jogoGenero);
    }
}
