using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tellurian.WagonCardApp.Shared.Tests;

[TestClass]
public class CheckNumberTests
{
    [DataTestMethod]
    [DataRow("21812471217", 3)]
    [DataRow("51800843001", 0)]
    [DataRow("23764268057", 1)]
    [DataRow("31816650286", 0)]
    [DataRow("42744430226", 4)]
    [DataRow("42744430336", 1)]
    public void UicCheckSumTest(string elevenDigits, int expectedControlDigit)
    {
        Assert.AreEqual(expectedControlDigit, elevenDigits.UicCheckSum(), elevenDigits);
    }




    [DataTestMethod]
    [DataRow("393 3 013", "31853933013")]
    [DataRow("393 3 0135", "")]
    [DataRow("393013", "")]
    public void VehicleElevenDigitsTests(string vehicleNumber, string expectedDigits)
    {
        var target = new Wagon
        {
            CountryRegistrationNumber = 85,
            InteroperatbilityNumber = 31,
            VehicleNumber = vehicleNumber
        };
        Assert.AreEqual(expectedDigits, target.ElevenDigitNumber());
    }


    [TestMethod]
    public void VehicleNumberDigits()
    {
        var target = new Wagon
        {
            VehicleNumber = "393301"
        };
        Assert.AreEqual("393301", target.VehicleNumberDigits());
    }

    [TestMethod]
    public void VehicleIdentoficationTest()
    {
        var target = new Wagon
        {
            OperatorSignature = "DB",
            VehicleClass = "Habins",
            CountryRegistrationNumber = 80,
            InteroperatbilityNumber = 31,
            VehicleNumber = "393 3 013"
        };
        var identification = target.Identification();
        Assert.AreEqual("D-DB Habins 393 3 013-5", identification);
    }

}
