using LabProject.Factory;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Handler
{
    public class MakeupHandler
    {
        public static List<Makeup> GetMakeupList()
        {
            return MakeupRepository.GetMakeupList();
        }

        public static List<MakeupType> GetMakeupTypeList()
        {
            return MakeupRepository.GetMakeupTypeList();
        }

        public static List<MakeupBrand> GetMakeupBrandList()
        {
            return MakeupRepository.GetMakeupBrandList();
        }

        public static int getLastTypeID()
        {
            MakeupType makeupType = MakeupRepository.getLastMakeupType();
            if(makeupType == null)
            {
                return 0;
            }
            int lastTypeID = makeupType.MakeupTypeID;
            return lastTypeID;
        }

        public static int getLastBrandID()
        {
            MakeupBrand makeupBrand = MakeupRepository.getLastMakeupBrand();
            if(makeupBrand == null)
            {
                return 0;
            }
            int lastBrandID = makeupBrand.MakeupBrandID;
            return lastBrandID;
        }

        public static int generateMakeupID()
        {
            Makeup makeup = MakeupRepository.GetLastMakeup();
            if (makeup == null)
            {
                return 1;
            }
            int lastId = makeup.MakeupID;
            lastId++;
            return lastId;
        }

        public static int generateTypeID()
        {
            int lastId = getLastTypeID();
            lastId++;
            return lastId;
        }

        public static int generateBrandID()
        {
            int lastId = getLastBrandID();
            lastId++;
            return lastId;
        }

        public static Response<Makeup> addMakeup(string name, int price, int weight, int typeID, int brandID)
        {
            Makeup makeup = MakeupFactory.Create(generateMakeupID(), name, price, weight, typeID, brandID);
            MakeupRepository.addMakeup(makeup);
            return new Response<Makeup>()
            {
                Message = "Succesfully added makeup",
                IsSuccess = true,
                Payload = makeup
            };
        }

        public static Response<MakeupType> addMakeupType(string name)
        {
            MakeupType makeupType = MakeupTypeFactory.Create(generateTypeID(), name);
            MakeupRepository.addMakeupType(makeupType);
            return new Response<MakeupType>()
            {
                Message = "Succesfully added makeup type",
                IsSuccess = true,
                Payload = makeupType
            };
        }

        public static Response<MakeupBrand> addMakeupBrand(string name, int rating)
        {
            MakeupBrand makeupBrand = MakeupBrandFactory.Create(generateBrandID(), name, rating);
            MakeupRepository.addMakeupBrand(makeupBrand);
            return new Response<MakeupBrand>()
            {
                Message = "Succesfully added makeup brand",
                IsSuccess = true,
                Payload = makeupBrand
            };
        }

        public static void removeMakeup(int id)
        {
            Makeup makeup = MakeupRepository.getMakeupByID(id);
            MakeupRepository.removeMakeup(makeup);
        }

        public static void removeMakeupType(int id)
        {
            MakeupType makeupType = MakeupRepository.getMakeupTypeByID(id);
            MakeupRepository.removeMakeupType(makeupType);
        }

        public static void removeMakeupBrand(int id)
        {
            MakeupBrand makeupBrand = MakeupRepository.getMakeupBrandByID(id);
            MakeupRepository.removeMakeupBrand(makeupBrand);
        }

        public static Makeup getMakeupByID(int id)
        {
            return MakeupRepository.getMakeupByID(id);
        }

        public static Response<Makeup> updateMakeup(int id, string name, int price, int weight, int typeID, int brandID)
        {
            Makeup makeup = getMakeupByID(id);
            makeup.MakeupName = name;
            makeup.MakeupPrice = price;
            makeup.MakeupWeight = weight;
            makeup.MakeupTypeID = typeID;
            makeup.MakeupBrandID = brandID;

            MakeupRepository.updateMakeup(makeup);

            return new Response<Makeup>()
            {
                Message = "Succesfully update Makeup",
                IsSuccess = true,
                Payload = makeup
            }; ;
        }

        public static MakeupType getMakeupTypeByID(int id)
        {
            return MakeupRepository.getMakeupTypeByID(id);
        }

        public static Response<MakeupType> updateMakeupType(int id, string name)
        {
            MakeupType makeupType = getMakeupTypeByID(id);
            makeupType.MakeupTypeName = name;

            MakeupRepository.updateMakeupType(makeupType);

            return new Response<MakeupType>()
            {
                Message = "Succesfully update Makeup Type",
                IsSuccess = true,
                Payload = makeupType
            };
        }

        public static MakeupBrand GetMakeupBrandByID(int id)
        {
            return MakeupRepository.getMakeupBrandByID(id);
        }

        public static Response<MakeupBrand> updateMakeupBrand(int id, string name, int rating)
        {
            MakeupBrand makeupBrand = GetMakeupBrandByID(id);
            makeupBrand.MakeupBrandName = name;
            makeupBrand.MakeupBrandRating = rating;

            MakeupRepository.updateMakeupBrand(makeupBrand);

            return new Response<MakeupBrand>()
            {
                Message = "Succesfully update Makeup Brand",
                IsSuccess = true,
                Payload = makeupBrand
            };
        }

        public static List<Makeup> GetMakeupListByID(int id)
        {
            return MakeupRepository.GetMakeupListByID(id);
        }
    }
}