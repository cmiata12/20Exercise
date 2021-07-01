using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarNS;
using System.Runtime.Serialization; //what the heck are these?? 

namespace CarTests
{
    [TestClass]
    public class CarTests
    {

        Car test_car;

        //TODO: add emptyTest so we can configure our runtime environment (remove this test before pushing to your personal GitHub account)
        //TODO: constructor sets gasTankLevel properly
      

      [TestInitialize]
       public void CreateCarObject()
      {
            test_car = new Car("Toyota", "Prius", 10, 50);
      }



        //TODO: gasTankLevel is accurate after driving within tank range

        [TestMethod]
        public void Drive()
        {
            test_car.Drive(500);
            Assert.AreEqual(9, test_car.GasTankLevel, .001);
        }

        //TODO: gasTankLevel is accurate after attempting to drive past tank range

        [TestMethod]
        public void TestGasTankAfterExceedingTankRange()  // how to do naming convention? 
        {
            test_car.Drive(50);
            Assert.AreEqual(55, test_car.GasTankSize, 0.001);
        }
        //TODO: can't have more gas than tank size, expect an exception

        [TestMethod]

        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void TestGasOverfillException()
        {
            test_car.AddGas(5);
            Assert.Fail("Shouldn't get here, car cannot have more gas in tank than the size of the tank");
        }

        [TestMethod]
        public void ArgumentOutOfRangeException(int GasTankLevel, int GasTankSize)
        {
            if (GasTankLevel > GasTankSize)
            {
                throw new ArgumentOutOfRangeException("Can't exceed tank size");
            }
        }

           
        
    }

    [System.Serializable]
    internal class ArgumentOutOfRangeException : System.Exception
    {
        public ArgumentOutOfRangeException()
        {
        }

        public ArgumentOutOfRangeException(string message) : base(message)
        {
        }

        public ArgumentOutOfRangeException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected ArgumentOutOfRangeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
