using ConfigSetting.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigSetting.UnitTest
{
    [TestClass]
    public class DbProviderTest
    {
        [TestMethod]
        public void DbProviderMethod()
        {
            var result = DbProvider.Instance.UpdateSettingValue(null);
            Assert.AreEqual(result, false);
        }
    }
}
