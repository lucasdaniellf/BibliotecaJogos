using AD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Model;
using Newtonsoft.Json;
using NG;
using Npgsql;
using System.Collections.Generic;

namespace BibliotecaJogos.Pages
{
    public class ConfiguracoesBackupModel : PageModel
    {
        private readonly string _conn;
        private readonly BibliotecaServiceNG _bibliotecaNG;
        private readonly BibliotecaServiceAD _bibliotecaAD;

        public List<Estudio> estudioList;
        public List<Genero> generoList;

        [BindProperty]
        public Estudio estudio { get; set; }
        
        [BindProperty]
        public Genero genero { get; set; }

        public ConfiguracoesBackupModel(IOptions<DataBaseContext> options, BibliotecaServiceNG bibliotecaNG, BibliotecaServiceAD bibliotecaAD )
        {
            _conn = options.Value.SqlConnection;
            _bibliotecaNG = bibliotecaNG;
            _bibliotecaAD = bibliotecaAD;
        }
        public void OnGet()
        {
            if(TempData["sucesso_config"] != null || TempData["erro_config"] != null)
            {
                ViewData["status_update"] = TempData["erro_config"] ?? TempData["sucesso_config"];

                estudio = TempData["estudio_insert"] != null ?
                                                  JsonConvert.DeserializeObject<Estudio>((string)TempData["estudio_insert"]) : null ;

                genero = TempData["genero_insert"] != null ?
                                  JsonConvert.DeserializeObject<Genero>((string)TempData["estudio_insert"]) : null;

                TempData.Clear();
            }
            estudioList = _bibliotecaNG.SelectTodosEstudios(_conn, _bibliotecaAD);
            generoList = _bibliotecaNG.SelectTodosGeneros(_conn, _bibliotecaAD);
        }

        public ActionResult OnPostAdicionarEstudio()
        {
            if(ModelState.ErrorCount <= 1)
            {
                try
                {
                    int row = _bibliotecaNG.InsertEstudio(_conn, _bibliotecaAD, estudio);
                    if (row > 0)
                    {
                        TempData["sucesso_config"] = "0 - Estúdio adicionado com sucesso!";
                        return RedirectToPage("/Configuracoes");
                    }
                    TempData["erro_config"] = "1 - Falha ao adicionar o estúdio!";
                    TempData["estudio_insert"] = JsonConvert.SerializeObject(estudio);
                } catch (NpgsqlException)
                {
                    return RedirectToPage("/Error");
                }
            }
            else
            {
                TempData["erro_config"] = "1 - Erro no preenchimento dos campos de estúdio!";
            }
            return RedirectToPage("/Configuracoes");
        }
        public ActionResult OnPostAdicionarGenero()
        {
            if (ModelState.ErrorCount <= 1)
            {
                try
                {
                    int row = _bibliotecaNG.InsertGenero(_conn, _bibliotecaAD, genero);
                    if (row > 0)
                    {
                        TempData["sucesso_config"] = "0 - Gênero adicionado com sucesso!";
                        return RedirectToPage("/Configuracoes");
                    }
                    TempData["erro_config"] = "1 - Falha ao adicionar o gênero!";
                    TempData["genero_insert"] = JsonConvert.SerializeObject(genero);
                } catch (NpgsqlException)
                {
                    return  RedirectToPage("/Error");
                }
            }
            else
            {
                TempData["erro_config"] = "1 - Erro no preenchimento dos campos de gênero!";
            }
            return RedirectToPage("/Configuracoes");

        }

        public ActionResult OnPostDeleteEstudio(int id)
        {
            try
            {
                int rows = _bibliotecaNG.DeleteEstudio(_conn, _bibliotecaAD, id);
                if (rows > 0)
                {
                    TempData["sucesso_config"] = "0 - Estudio deletado com sucesso !";
                }
                return RedirectToPage("/Configurcoes");
            }
            catch (NpgsqlException)
            {
                return RedirectToPage("/Error");
            }
        }

        public ActionResult OnPostDeleteGenero(int id)
        {
            try
            {
                int rows = _bibliotecaNG.DeleteGenero(_conn, _bibliotecaAD, id);
                if (rows > 0)
                {
                    TempData["sucesso_config"] = "0 -  Genero deletado com sucesso !";
                }
                return RedirectToPage("/Configurcoes");
            }
            catch (NpgsqlException)
            {
                return RedirectToPage("/Error");
            }
        }
    }
}
