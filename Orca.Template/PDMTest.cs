/*By using Orca and this template, you acknowledge and agree to all the terms of usage and conditions specified at this link
https://raw.githubusercontent.com/BlueByteSystemsInc/Orca.Docs/main/LICENSE.md
If the terms of usage and conditions are not accessible, please request a copy from amen@bluebyte.biz or by contacting us from www.bluebyte.biz
*/
using BlueByte.SOLIDWORKS.PDMProfessional.UnitTesting;
using BlueByte.SOLIDWORKS.PDMProfessional.UnitTesting.Attributes;
using EPDM.Interop.epdm;
using System;

namespace $safeprojectname$
{
    public static class LicenseInformation
    {
        public static string licensePath = @"$xmllicensefile$";
    }

    #region startup
    class Host
    {


        [STAThread]
        static void Main(string[] args)
        {
            string licenseKey = string.Empty;


            licenseKey = System.IO.File.ReadAllText(LicenseInformation.licensePath);

            var instance = new PDMTest(licenseKey);

            instance.Run();
            Console.ReadLine();
        }
    }

    #endregion

    /// <summary>
    /// Todo: 
    /// change T to your a class that implements <see cref="IEdmAddIn5"/>
    /// change TestVault to use your testing vault
    /// </summary>
    [TestVault(Name = "$pdmvault$")]
    public class PDMTest : TestableAddInBase<T>
    {
        #region Constructor
        public PDMTest(string licenseKey) : base(licenseKey)
        {

        }

        #endregion

        #region GetAddInInfo
        /// <summary>
        /// This methods is invoked at the start of every test run and calls <see cref="IEdmAddIn5.GetAddInInfo(ref EdmAddInInfo, IEdmVault5, IEdmCmdMgr5)()"/>
        /// </summary>
        public override void Startup()
        {
            base.Startup();
        }

        #endregion

        [PDMTestMethod()]
        public void TestMethod()
        {

        }

    }

    #region placeholder add-in
    public class T : IEdmAddIn5
    {
        public void GetAddInInfo(ref EdmAddInInfo poInfo, IEdmVault5 poVault, IEdmCmdMgr5 poCmdMgr)
        {
            throw new NotImplementedException("Use your own add-in class!");
        }

        public void OnCmd(ref EdmCmd poCmd, ref EdmCmdData[] ppoData)
        {
            throw new NotImplementedException("Use your own add-in class!");
        }
    }

    #endregion
}
