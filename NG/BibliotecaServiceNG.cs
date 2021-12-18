using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NG
{
    public interface BibliotecaServiceNG
    {
        //--------------------Jogo-------------------------------//
        public List<Jogo> SelectTotosJogos(string connectionString, AD.BibliotecaServiceAD serviceAD);

        public Jogo SelectJogoPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);

        public List<Jogo> ProcurarJogoPorNome(string connectionString, AD.BibliotecaServiceAD serviceAD, string nome);

        public int DeleteJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);

        public int InsertJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, Jogo jogo);

        public int UpdateJogo(string connectionString, AD.BibliotecaServiceAD serviceAD, Jogo jogo);

        //--------------------Genero-------------------------------//

        public List<Genero> SelectTodosGeneros(string connectionString, AD.BibliotecaServiceAD serviceAD);
        public Genero SelectGeneroPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int DeleteGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int InsertGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, Genero genero);
        public int UpdateGenero(string connectionString, AD.BibliotecaServiceAD serviceAD, Genero genero);

        //--------------------Estudio-------------------------------//
        public List<Estudio> SelectTodosEstudios(string connectionString, AD.BibliotecaServiceAD serviceAD);
        public Estudio SelectEstudioPorID(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int DeleteEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int InsertEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, Estudio estudio);
        public int UpdateEstudio(string connectionString, AD.BibliotecaServiceAD serviceAD, Estudio estudio);

        //--------------------JogoGenero-------------------------------//
        public List<JogoGenero> SelectJogoGenerosPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public List<JogoGenero> SelectJogoGenerosPorGeneroId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int DeleteJogoGeneroPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, int id);
        public int InsertJogoGeneroPorJogoId(string connectionString, AD.BibliotecaServiceAD serviceAD, JogoGenero jogoGenero);
    }
}

