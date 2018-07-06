using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atleta.Model
{
    class Atleta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Posicao { get; set;}
        public string Time { get; set; }
    }
}
