using System;
using System.Reflection;
using NUnit.Framework;

namespace Xamarin.Amplitude.iOS.Test
{
    [TestFixture]
    public class BindingsTest
    {
        [Test]
        public void TestInit()
        {
            Assert.NotNull(Amplitude.Instance);
        }

        [Test]
        public void TestInitWithToken()
        {
            const string apiKey = "asdf";
            Amplitude.Instance.InitializeApiKey(apiKey);
            Assert.AreEqual(apiKey, Amplitude.Instance.ApiKey);
        }

        private static object[] GetAmplitudeMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(Amplitude.Instance);

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPConfigManagerMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPConfigManager());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPDatabaseHelperMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPDatabaseHelper());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPDeviceInfoMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPDeviceInfo());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPIdentifyMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPIdentify());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPRevenueMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPRevenue());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPTrackingOptionsMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(new AMPTrackingOptions());

        // ReSharper disable once InconsistentNaming
        private static object[] GetAMPUtilsMethodsToTest() =>
            BindingTestDataProvider.GetMethodsOfStaticTypeToTest(typeof(AMPUtils));

        // ReSharper disable once InconsistentNaming
        private static object[] GetConstantsMethodsToTest() =>
            BindingTestDataProvider.GetMethodsOfStaticTypeToTest(typeof(Constants));

        private static object[] GetSessionEventConstantsMethodsToTest() =>
            BindingTestDataProvider.GetMethodsOfStaticTypeToTest(typeof(SessionEventConstants));

        private static object[] GetAmplitude_MethodsToTest() =>
            BindingTestDataProvider.GetMethodsOfStaticTypeToTest(typeof(Amplitude_));

        [Test]
        public void TestDataGenerators()
        {
            GetAMPConfigManagerMethodsToTest();
            GetAMPDatabaseHelperMethodsToTest();
            GetAMPDeviceInfoMethodsToTest();
            GetAMPIdentifyMethodsToTest();
            GetAMPRevenueMethodsToTest();
            GetAMPTrackingOptionsMethodsToTest();

            GetAMPUtilsMethodsToTest();

            GetConstantsMethodsToTest();
            GetSessionEventConstantsMethodsToTest();
            GetAmplitude_MethodsToTest();
        }

        [Test, TestCaseSource(nameof(GetAmplitude_MethodsToTest))]
        public void TestAmplitude_Methods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPConfigManagerMethodsToTest))]
        public void TestAMPConfigManagerMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPDatabaseHelperMethodsToTest))]
        public void TestAMPDatabaseHelperMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPDeviceInfoMethodsToTest))]
        public void TestAMPDeviceInfoMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPIdentifyMethodsToTest))]
        public void TestAMPIdentifyMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPRevenueMethodsToTest))]
        public void TestAMPRevenueMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPTrackingOptionsMethodsToTest))]
        public void TestAMPTrackingOptionsMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        [Test, TestCaseSource(nameof(GetSessionEventConstantsMethodsToTest))]
        public void TestSessionEventConstantsMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        [Test, TestCaseSource(nameof(GetConstantsMethodsToTest))]
        public void TestConstantsMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        // ReSharper disable once InconsistentNaming
        [Test, TestCaseSource(nameof(GetAMPUtilsMethodsToTest))]
        public void TestAMPUtilsMethods(object instance, MethodInfo method, object[] parameters) =>
            TestMethod(instance, method, parameters);

        private static void TestMethod(object instance, MethodInfo method, object[] parameters)
        {
            try
            {
                if (method.IsStatic)
                {
                    method.Invoke(null, parameters);
                }
                else if (instance == null)
                {
                    Assert.Fail($"failed to execute method {method} (instance needed for non-static methods)");
                }
                else
                {
                    method.Invoke(instance, parameters);
                }
            }
            catch (Exception e)
            {
                Assert.Fail($"failed to execute method {method} (message: {e.Message})");
            }
        }
    }
}
