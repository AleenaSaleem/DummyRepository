using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public class IcuRepository
    {
        public readonly string _csvFilePath;
        private readonly Utility.IcuDataHandler _icuDataHandler = new Utility.IcuDataHandler();
        private readonly Utility.Helpers _helpers = new Utility.Helpers();
        public IcuRepository()
        {
            _csvFilePath = "";
        }

        // Add update vitals in maintanance. 
        public bool AddIcu(Models.IcuModel newIcu)
        {
            bool isAdded = false;
            try
            {
                //Validation
                string message;
                if (_helpers.IsIcuEligibleToBeAdded(newIcu, out message))
                {
                    isAdded = _icuDataHandler.WriteIcu(newIcu, _csvFilePath);
                }
            }
            catch (Exception e)
            {
                isAdded = false;
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return isAdded;
        }

        public bool RemoveIcu(string icuId)
        {
            bool isDeleted = false;
            try
            {
                // validation
                string message;
                if (_helpers.CanIcuBeRemoved(icuId, out message))    // Check for patients if no patirnts then remove
                {
                    isDeleted = _icuDataHandler.DeleteIcu(icuId, _csvFilePath);

                }
            }
            catch (Exception e)
            {
                isDeleted = false;
                Console.WriteLine(e.StackTrace);
            }
            return isDeleted;
        }

        public IEnumerable<Models.IcuModel> GetAllIcu()
        {
            return _icuDataHandler.ReadIcus(_csvFilePath);
        }

        public Models.IcuModel GetIcu(string id)
        {
            return _icuDataHandler.ReadIcus(_csvFilePath).Find(icu => icu.IcuId == id);
        }

    }
}
