using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaysHotDogs.Core.Model;
using RaysHotDogs.Core.Repository;

namespace RaysHotDogs.Core.Service
{
    public class HotDogDataService
    {
        private static HotDogRepository hotDogRespository = new HotDogRepository();

        public List<HotDogGroup> GetGroupedHotDogs()
        {
            return hotDogRespository.GetGroupedHotDogs();
        }

        public List<HotDog> GetAllHotDogs()
        {
            return hotDogRespository.GetAllHotDogs();
        }

        public List<HotDog> GetHotDogsForGroup(int hotDogGroupId)
        {
            return hotDogRespository.GetHotDogsForGroup(hotDogGroupId);
        }

        public List<HotDog> GetFavoriteHotDogs()
        {
            return hotDogRespository.GetFavoriteHotDogs();
        }

        public HotDog GetHotDogById(int hotDogId)
        {
            return hotDogRespository.GetHotDogById(hotDogId);
        }
    }
}
