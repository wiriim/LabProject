using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class MakeupFactory
    {
        public static Makeup Create(int makeupID, string makeupName, int makeupPrice, int makeupWeight, int makeupTypeID, int makeupBrandID)
        {
            Makeup makeup = new Makeup() 
            {
                MakeupID = makeupID,
                MakeupName = makeupName,
                MakeupPrice = makeupPrice,
                MakeupWeight = makeupWeight,
                MakeupTypeID = makeupTypeID,
                MakeupBrandID = makeupBrandID
            };

            return makeup;
        }
    }
}