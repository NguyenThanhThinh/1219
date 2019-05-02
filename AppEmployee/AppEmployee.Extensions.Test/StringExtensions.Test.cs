using NUnit.Framework;
using AppEmployee.WinForms.Extensions;

namespace AppEmployee.Extensions.Test
{
    [TestFixture]
    public class StringExtensionsTest
    {
        [Test]
        public void Test1()
        {
           
            Assert.AreEqual("NV00000901", StringExtensions.AutoGenerateId("NV",""));

        }
    }
}
