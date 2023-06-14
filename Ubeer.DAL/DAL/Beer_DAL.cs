using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ubeer.DAL.DAL
{
    public class Beer_DAL
    {
        public string ID { get; set; }

        public string IdStyle { get; set; }

        public string Libelle { get; set; }

        public float AlcoholVolume { get; set; }

        public float UnitPrice { get; set; }

		public DateTime Creation { get; set; }

		public DateTime LastUpdate { get; set; }

        public string Image { get; set; }

		public Beer_DAL(string id, string idStyle, string libelle, float alcoholVolume, float unitPrice, DateTime creation, DateTime lastUpdate, string image) => (ID, IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image) = (id, idStyle, libelle, alcoholVolume, unitPrice, creation, lastUpdate, image);
        public Beer_DAL(string idStyle, string libelle, float alcoholVolume, float unitPrice, DateTime creation, DateTime lastUpdate, string image) => (IdStyle, Libelle, AlcoholVolume, UnitPrice, Creation, LastUpdate, Image) = (idStyle, libelle, alcoholVolume, unitPrice, creation, lastUpdate, image);

    }
}
