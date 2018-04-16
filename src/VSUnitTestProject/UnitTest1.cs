using Microsoft.VisualStudio.TestTools.UnitTesting;
using Morabaraba_9001.GameCode;

// Source: https://www.c-sharpcorner.com/UploadFile/7ca517/unit-test-with-console-application/
// Remember: nuget fron quick launch top right -> update to have all needed packages
// To test: right click test method, then click "run test" (ctrl+r,t)
// Note you may see an error: Error NU1105  Unable to find project information for ...
//        This doesnt matter currently, check test explorer on left

namespace VSUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCanWeCreateGame()
        {
            Game game = new Game();
        }
    }
}
