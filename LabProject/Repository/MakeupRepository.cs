using LabProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Repository
{
    public class MakeupRepository
    {
        public static Database1Entities2 db = new Database1Entities2();
        public static List<Makeup> GetMakeupList()
        {
            return (from Makeup in db.Makeups select Makeup).ToList();
        }

        public static Makeup GetLastMakeup()
        {
            Makeup makeup = db.Makeups.ToList().LastOrDefault();
            return makeup;
        }

        public static void addMakeup(Makeup makeup)
        {
            db.Makeups.Add(makeup);
            db.SaveChanges();
        }

        public static void removeMakeup(Makeup makeup)
        {
            db.Makeups.Remove(makeup);
            db.SaveChanges();
        }

        public static Makeup getMakeupByID(int id)
        {
            Makeup makeup = db.Makeups.Find(id);
            return makeup;
        }

        public static void updateMakeup(Makeup makeup)
        {
            Makeup makeups = makeup;

            db.SaveChanges();
        }

        public static List<Makeup> GetMakeupListByID(int id)
        {
            return (from Makeup in db.Makeups where Makeup.MakeupID == id select Makeup).ToList();
        }

        public static List<MakeupBrand> GetMakeupBrandList()
        {
            return (from MakeupBrand in db.MakeupBrands orderby MakeupBrand.MakeupBrandRating descending select MakeupBrand).ToList();
        }

        public static MakeupBrand getLastMakeupBrand()
        {
            MakeupBrand makeupBrand = db.MakeupBrands.ToList().LastOrDefault();
            return makeupBrand;
        }

        public static void addMakeupBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Add(makeupBrand);
            db.SaveChanges();
        }

        public static void removeMakeupBrand(MakeupBrand makeupBrand)
        {
            db.MakeupBrands.Remove(makeupBrand);
            db.SaveChanges();
        }

        public static MakeupBrand getMakeupBrandByID(int id)
        {
            MakeupBrand makeupBrand = db.MakeupBrands.Find(id);
            return makeupBrand;
        }

        public static void updateMakeupBrand(MakeupBrand makeupBrand)
        {
            MakeupBrand makeupBrands = makeupBrand;
            db.SaveChanges();
        }

        public static List<MakeupType> GetMakeupTypeList()
        {
            return (from MakeupType in db.MakeupTypes select MakeupType).ToList();
        }

        public static MakeupType getLastMakeupType()
        {
            MakeupType makeupType = db.MakeupTypes.ToList().LastOrDefault();
            return makeupType;
        }

        public static void addMakeupType(MakeupType makeupType)
        {
            db.MakeupTypes.Add(makeupType);
            db.SaveChanges();
        }

        public static void removeMakeupType(MakeupType makeupType)
        {
            db.MakeupTypes.Remove(makeupType);
            db.SaveChanges();
        }

        public static MakeupType getMakeupTypeByID(int id)
        {
            MakeupType makeupType = db.MakeupTypes.Find(id);
            return makeupType;
        }

        public static void updateMakeupType(MakeupType makeupType)
        {
            MakeupType makeupTypes = makeupType;

            db.SaveChanges();
        }
    }
}