using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoxVolumeCalTrialExameASW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxVolumeCalTrialExameASW.Tests
{
    [TestClass()]
    public class BoxCalServiceTests
    {
        [TestMethod()]
        public void GetVolumeTest()
        {
            //Arrange

            BoxCalService service = new BoxCalService();

            //Act

            //service.GetVolume(2, 2, 2);

            //Assert

            Assert.AreEqual(8, service.GetVolume(2, 2, 2));
        }

        [TestMethod()]
        public void GetSideTest()
        {
            //Arrange

            BoxCalService service = new BoxCalService();

            //Act

            //service.GetSide(8,2,2);

            //Assert

            Assert.AreEqual(2, service.GetSide(8,2,2));
        }
    }
}