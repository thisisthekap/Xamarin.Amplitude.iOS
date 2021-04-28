using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using Xamarin.Amplitude.iOS;

namespace Sepp.Mobile.AmplitudeBindings.iOS.Test
{
    public static class BindingTestDataProvider
    {
        public static object[] GetMethodsToTest(Type typeToTest)
        {
            List<object> ret = new List<object>();
            var methods = typeToTest.GetMethods()
                .Where(m => m.IsPublic)
                .Where(m => m.DeclaringType == typeToTest)
                .Where(m => m.Name != nameof(Amplitude.InitializeApiKey))
                .ToList();
            if (methods.Count == 0)
            {
                throw new ArgumentException($"type {typeToTest} has no methods to test");
            }

            foreach (var method in methods)
            {
                var parameters = method.GetParameters().Select(p =>
                {
                    Type pType = p.ParameterType;
                    var ctor = pType.GetConstructor(Type.EmptyTypes);

                    if (ctor != null)
                    {
                        return ctor.Invoke(new object[] { });
                    }

                    if (pType == typeof(string))
                    {
                        return $"b-{Guid.NewGuid()}";
                    }

                    if (pType == typeof(bool))
                    {
                        return true;
                    }

                    if (pType == typeof(long))
                    {
                        return -1L;
                    }

                    if (pType == typeof(NSNumber))
                    {
                        return new NSNumber(-2);
                    }

                    if (pType == typeof(nint))
                    {
                        return (nint)(-3);
                    }

                    if (pType == typeof(int))
                    {
                        return (int)(-4);
                    }

                    if (pType == typeof(AMPAdSupportBlock))
                    {
                        return (AMPAdSupportBlock)(() => "a");
                    }

                    if (pType == typeof(AMPLocationInfoBlock))
                    {
                        return (AMPLocationInfoBlock)(() => new NSDictionary(new NSString("a"), new NSString("b")));
                    }

                    throw new ArgumentException($"parameter type not supported: {pType} (method: {method})");
                }).ToArray();
                ret.Add(new object[] { method, parameters });
            }

            return ret.ToArray();
        }
    }
}
