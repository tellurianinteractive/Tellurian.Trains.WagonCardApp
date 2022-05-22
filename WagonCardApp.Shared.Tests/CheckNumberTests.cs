using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tellurian.WagonCardApp.Shared;

namespace WagonCardApp.Shared.Tests;
[TestClass]
public class CheckNumberTests
{
    [TestMethod]
    public void UicCheckSumTest1()
    {
        var target = new Wagon { 
            CountryRegistrationNumber = 85, 
            InteroperatbilityNumber=31, 
            VehicleNumber="393 3 013" };
        var checkDigit = target.CalculateUicCheckSum();
        Assert.IsTrue(checkDigit >= 0 && checkDigit < 10);
    }
}