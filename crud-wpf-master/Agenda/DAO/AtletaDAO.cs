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

        public static bool AdicionarAtleta(Model.Atleta atleta)
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

        public static bool RemoverAtleta(Model.Atleta atleta)
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

        public static bool AlterarAtleta(Model.Atleta c)
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

      
    }
}
