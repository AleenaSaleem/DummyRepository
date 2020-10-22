using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IIcuRepository
    {
        bool AddIcu(IcuModel newIcu);
        IEnumerable<IcuModel> GetAllIcu();
        IcuModel GetIcu(string id);
        bool RemoveIcu(string icuId);
    }
}