using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTO;
using BLL;

namespace TDD
{
    [TestClass]
    public class Localization
    {
        [TestMethod]
        public void Get_Not_Null_Localization()
        {
            int idLocalization = 1;
            var localizationBO = new LocalizationBO();
            Assert.IsNotNull(localizationBO.Get(idLocalization));
        }

        [TestMethod]
        public void Get_Empty_Localization()
        {
            var localizationBO = new LocalizationBO();
            var localization = localizationBO.Get(0);
            Assert.AreEqual(0, localization.IdLocalization);
            Assert.IsNull(localization.Estate);
            Assert.AreEqual(0, localization.Latitude);
            Assert.AreEqual(0, localization.Longitude);
        }

        [TestMethod]
        public void Get_Valid_Distance()
        {
            var localizationBO = new LocalizationBO();
            var source = new DTO.Localization();
            var target = new DTO.Localization();

            // São Paulo
            source.Latitude = -23.552559;
            source.Longitude = -46.632424;

            // Rio de Janeiro
            target.Latitude = -22.969477;
            target.Longitude = -43.187558;

            double distance = localizationBO.Distance(source, target);
            Assert.IsTrue(distance > 0);
            Assert.AreEqual<Int32>(358, Convert.ToInt32(distance));
        }
    }
}
