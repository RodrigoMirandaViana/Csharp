using Atleta.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Atleta.DAO
{
    class AtletaDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarAtleta(Model.AtletaModel atleta)
        {
            try
            {
                ctx.Atletas.Add(atleta);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool RemoverAtleta(Model.AtletaModel atleta)
        {
            try
            {
                ctx.Atletas.Remove(atleta);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool AlterarAtleta(Model.AtletaModel c)
        {
            try
            {
                ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }

        public static IList<AtletaModel> ListarAtletasPorNome(string nome)
        {
            return ctx.Atletas.Where(a => a.Nome.ToLower() == nome.ToLower()).ToList();
        }

        public static IList<AtletaModel> ListarAtletasPorPosicao(string posicao)
        {
            return ctx.Atletas.Where(a => a.Posicao.ToLower() == posicao.ToLower()).ToList();
        }

        public static IList<AtletaModel> ListarAtletasPorTime(string time)
        {
            return ctx.Atletas.Where(a => a.Time.ToLower() == time.ToLower()).ToList();
        }


    }
}
