using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscritorioFerme
{
    public class ComboboxItemLlenado
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public ComboboxItemLlenado()
        {

        }
        public override string ToString()
        {
            return Texto;
        }
    }
}
