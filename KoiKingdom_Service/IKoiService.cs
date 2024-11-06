using KoiKingdom_BusinessObject;
using KoiKingdom_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiKingdom_Service
{
    public interface IKoiService
    {
        public bool AddKoi(Koi koi);

        public bool DeleteKoi(int koiId);

        public Koi GetKoiById(int id);

        public List<Koi> GetKois();

        public bool UpdateKoi(Koi koi) ;

        public List<string> GetKoisName();
    }
}
