using DateMePlease.Controllers;
using DateMePlease.Entities;
using System.Collections.Generic;
namespace DateMePlease.Data
{
    public interface IDateMePleaseRepository
    {
        Profile GetProfileByUserName(string username);
        Profile GetProfile(string memberName);
        List<RandomProfileViewModel> GetRandomProfiles(int numberToReturn);

        List<InterestType> GetInterestTypes();

        bool SaveAll();
    }
}
