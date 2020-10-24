using Backend.Models;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IBedRepository
    {
        bool AddBed(string icuId, string locationOfBed = "not specified");
        IEnumerable<BedModel> GetAllBedsFromAnIcu(string icuId);
        bool RemoveBed(string icuId, string bedId);
    }
}