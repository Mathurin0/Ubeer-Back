using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubeer.DAL.DAL;
using Ubeer.DAL.Depot;

namespace Ubeer.METIER.Metier
{
    public class Beer_METIER
	{
        public int ID { get; set; }

        public int IdStyle { get; set; }

        public string Libelle { get; set; }

        public float AlcoholVolume { get; set; }

        public float UnitPrice { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

		public string Image { get; set; }

		public Beer_METIER(int id, int idStyle, string libelle, float alcoholVolume, float unitPrice, DateTime creation, DateTime lastUpdate, string image) => (ID, IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image) = (id, idStyle, libelle, alcoholVolume, unitPrice, creation, lastUpdate, image);
		public Beer_METIER(int idStyle, string libelle, float alcoholVolume, float unitPrice, DateTime creation, DateTime lastUpdate, string image) => (IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image) = (idStyle, libelle, alcoholVolume, unitPrice, creation, lastUpdate, image);

	}
}
