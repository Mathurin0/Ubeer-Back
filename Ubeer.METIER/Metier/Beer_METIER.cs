using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.METIER.Metier
{
    public class Beer_METIER
	{
        public int Id { get; set; }

        public int IdStyle { get; set; }

        public string Libelle { get; set; }

        public float AlcoholVolume { get; set; }

        public float UnitPrice { get; set; }

        public Beer_METIER(int id, int idStyle, string libelle, float alcoholVolume, float unitPrice) => (Id, IdStyle, Libelle, AlcoholVolume, UnitPrice) = (id, idStyle, libelle, alcoholVolume, unitPrice);
        public Beer_METIER(int idStyle, string libelle, float alcoholVolume, float unitPrice) => (IdStyle, Libelle, AlcoholVolume, UnitPrice) = (idStyle, libelle, alcoholVolume, unitPrice);

    }
}
