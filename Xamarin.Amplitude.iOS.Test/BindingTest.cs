using System;
using System.Reflection;
using NUnit.Framework;
using Xamarin.Amplitude.iOS;

namespace Sepp.Mobile.AmplitudeBindings.iOS.Test
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
            BindingTestDataProvider.GetMethodsToTest(typeof(Amplitude));

        private static object[] GetRevenueMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(typeof(AMPRevenue));

        private static object[] GetIdentifyMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(typeof(AMPIdentify));

        private static object[] GetTrackingOptionsMethodsToTest() =>
            BindingTestDataProvider.GetMethodsToTest(typeof(AMPTrackingOptions));

        [Test]
        public void TestDataGenerators()
        {
            GetAmplitudeMethodsToTest();
            GetRevenueMethodsToTest();
            GetIdentifyMethodsToTest();
            GetTrackingOptionsMethodsToTest();
        }

        [Test, TestCaseSource(nameof(GetAmplitudeMethodsToTest))]
        public void TestAmplitudeMethods(MethodInfo method, object[] parameters)
        {
            try
            {
                method.Invoke(Amplitude.Instance, parameters);
            }
            catch (Exception e)
            {
                Assert.Fail($"failed to execute method {method} (message: {e.Message})");
            }
        }

        [Test, TestCaseSource(nameof(GetRevenueMethodsToTest))]
        public void TestRevenueMethods(MethodInfo method, object[] parameters)
        {
            try
            {
                method.Invoke(new AMPRevenue(), parameters);
            }
            catch (Exception e)
            {
                Assert.Fail($"failed to execute method {method} (message: {e.Message})");
            }
        }

        [Test, TestCaseSource(nameof(GetIdentifyMethodsToTest))]
        public void TestIdentifyMethods(MethodInfo method, object[] parameters)
        {
            try
            {
                method.Invoke(new AMPIdentify(), parameters);
            }
            catch (Exception e)
            {
                Assert.Fail($"failed to execute method {method} (message: {e.Message})");
            }
        }

        [Test, TestCaseSource(nameof(GetTrackingOptionsMethodsToTest))]
        public void TestTrackingOptionsMethods(MethodInfo method, object[] parameters)
        {
            try
            {
                method.Invoke(new AMPTrackingOptions(), parameters);
            }
            catch (Exception e)
            {
                Assert.Fail($"failed to execute method {method} (message: {e.Message})");
            }
        }
    }
}
