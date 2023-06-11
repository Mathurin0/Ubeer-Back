using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Beer_DAL
    {
        public int ID { get; set; }

        public int IdStyle { get; set; }

        public string Libelle { get; set; }

        public float AlcoholVolume { get; set; }

        public float UnitPrice { get; set; }

        public Beer_DAL(int id, int idStyle, string libelle, float alcoholVolume, float unitPrice) => (ID, IdStyle, Libelle, AlcoholVolume, UnitPrice) = (id, idStyle, libelle, alcoholVolume, unitPrice);
        public Beer_DAL(int idStyle, string libelle, float alcoholVolume, float unitPrice) => (IdStyle, Libelle, AlcoholVolume, UnitPrice) = (idStyle, libelle, alcoholVolume, unitPrice);

    }
}
