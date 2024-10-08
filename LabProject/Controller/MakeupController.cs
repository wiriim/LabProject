using LabProject.Handler;
using LabProject.Model;
using LabProject.Modules;
using LabProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabProject.Controller
{
    public class MakeupController
    {
        public static List<Makeup> GetMakeupList()
        {
            return MakeupHandler.GetMakeupList();
        }

        public static List<MakeupBrand> GetMakeupBrandList()
        {
            return MakeupHandler.GetMakeupBrandList();
        }

        public static List<MakeupType> GetMakeupTypeList()
        {
            return MakeupHandler.GetMakeupTypeList();
        }

        public static Response<Makeup> addMakeup(string name, int price, int weight, int typeID, int brandID)
        {
            if(name.Length < 1 || name.Length > 99)
            {
                return new Response<Makeup>()
                {
                    Message = "Makeup name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(price < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "Makeup price must be greater than or equals to 1",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(weight < 1 || weight > 1500)
            {
                return new Response<Makeup>()
                {
                    Message = "Make up weight cannot be less than 1 and cannot be greater than 1500",
                    IsSuccess = false,
                    Payload = null
                };
            }

            int lastTypeID = MakeupHandler.getLastTypeID();
            int lastBrandID = MakeupHandler.getLastBrandID();

            if (typeID > lastTypeID || typeID < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "please enter a valid Type ID",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (brandID > lastBrandID || brandID < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "please enter a valid Brand ID",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.addMakeup(name, price, weight, typeID, brandID);
            }
            return new Response<Makeup>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupType> addMakeupType(string name)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupType>()
                {
                    Message = "Makeup type name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.addMakeupType(name);
            }
            return new Response<MakeupType>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static Response<MakeupBrand> addMakeupBrand(string name, int rating)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupBrand>()
                {
                    Message = "Makeup brand name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if(rating < 0 || rating > 100)
            {
                return new Response<MakeupBrand>()
                {
                    Message = "Makeup brand rating must be between 0 - 100",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.addMakeupBrand(name, rating);
            }
            return new Response<MakeupBrand>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        } 

        public static void removeMakeup(int id)
        {
            MakeupHandler.removeMakeup(id);
        }

        public static void removeMakupType(int id)
        {
            MakeupHandler.removeMakeupType(id);
        }

        public static void removeMakeupBrand(int id)
        {
            MakeupHandler.removeMakeupBrand(id);
        }

        public static Makeup GetMakeupByID(int id)
        {
            return MakeupHandler.getMakeupByID(id);
        }

        public static Response<Makeup> updateMakeup(int id, string name, int price, int weight, int typeID, int brandID)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<Makeup>()
                {
                    Message = "Makeup name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (price < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "Makeup price must be greater than or equals to 1",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (weight < 1 || weight > 1500)
            {
                return new Response<Makeup>()
                {
                    Message = "Make up weight cannot be less than 1 and cannot be greater than 1500",
                    IsSuccess = false,
                    Payload = null
                };
            }

            int lastTypeID = MakeupHandler.getLastTypeID();
            int lastBrandID = MakeupHandler.getLastBrandID();

            if (typeID > lastTypeID || typeID < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "please enter a valid Type ID",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (brandID > lastBrandID || brandID < 1)
            {
                return new Response<Makeup>()
                {
                    Message = "please enter a valid Brand ID",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.updateMakeup(id, name, price, weight, typeID, brandID);
            }
            return new Response<Makeup>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static MakeupType GetMakeupTypeByID(int id)
        {
            return MakeupHandler.getMakeupTypeByID(id);
        }

        public static Response<MakeupType> updateMakeupType(int id, string name)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupType>()
                {
                    Message = "Makeup type name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.updateMakeupType(id, name);
            }
            return new Response<MakeupType>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static MakeupBrand getMakeupBrandByID(int id)
        {
            return MakeupHandler.GetMakeupBrandByID(id);
        }

        public static Response<MakeupBrand> updateMakeupBrand(int id, string name, int rating)
        {
            if (name.Length < 1 || name.Length > 99)
            {
                return new Response<MakeupBrand>()
                {
                    Message = "Makeup brand name length must be between 1-99 characters",
                    IsSuccess = false,
                    Payload = null
                };
            }

            if (rating < 0 || rating > 100)
            {
                return new Response<MakeupBrand>()
                {
                    Message = "Makeup brand rating must be between 0 - 100",
                    IsSuccess = false,
                    Payload = null
                };
            }

            string error = "";
            if (error.Equals(""))
            {
                return MakeupHandler.updateMakeupBrand(id, name, rating);
            }
            return new Response<MakeupBrand>()
            {
                Message = "Error",
                IsSuccess = false,
                Payload = null
            };
        }

        public static List<Makeup> GetMakeupListByID(int id)
        {
            return MakeupHandler.GetMakeupListByID(id);
        }
    }
}