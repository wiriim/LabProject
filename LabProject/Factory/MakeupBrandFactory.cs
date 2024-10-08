using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class MakeupBrandFactory
    {
        public static MakeupBrand Create(int makeupBrandID, string makeupBrandName, int makeupBrandRating)
        {
            MakeupBrand brand = new MakeupBrand()
            {
                MakeupBrandID = makeupBrandID,
                MakeupBrandName = makeupBrandName,
                MakeupBrandRating = makeupBrandRating
            };

            return brand;
        }
    }
}