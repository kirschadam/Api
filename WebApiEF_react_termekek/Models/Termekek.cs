using System;
using System.Collections.Generic;

#nullable disable

namespace WebApiEF_react_termekek.Models
{
    public partial class Termekek
    {
        public Termekek()
        {
            Megrendeleseks = new HashSet<Megrendelesek>();
            Megrendeloks = new HashSet<Megrendelok>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public string Keplink { get; set; }

        public virtual ICollection<Megrendelesek> Megrendeleseks { get; set; }
        public virtual ICollection<Megrendelok> Megrendeloks { get; set; }
    }
}
