using System;
using System.Collections.Generic;
using System.Linq;
using DTO;
using DAL;

namespace BLL
{
    public class LocalizationBO
    {
        public LocalizationBO()
        { }

        public Localization Get(int idLocalization)
        {
            var localization = new Localization();
           
            try 
            {
                var dao = new Persistence<Localization>();
                localization = dao.Get(String.Format("SELECT IdLocalization, Estate, Latitude, Longitude FROM Localization WHERE IdLocalization = {0}", idLocalization));
                return localization;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public double Distance(Localization pos1, Localization pos2)
        {
            double R = 6371;
            double dLat = this.toRadian(pos2.Latitude - pos1.Latitude);
            double dLon = this.toRadian(pos2.Longitude - pos1.Longitude);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(this.toRadian(pos1.Latitude)) * Math.Cos(this.toRadian(pos2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = R * c;
            return d;
        }

        private double toRadian(double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}
