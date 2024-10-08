using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Factory
{
    public class MakeupTypeFactory
    {
        public static MakeupType Create(int makeupTypeID, string makeupTypeName)
        {
            MakeupType type = new MakeupType()
            {
                MakeupTypeID = makeupTypeID,
                MakeupTypeName = makeupTypeName
            };

            return type;
        }
    }
}