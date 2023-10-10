using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.ReactNative;
using Microsoft.ReactNative.Managed;

namespace ReactNativeI18N
{
    [ReactModule("RNI18n")]
    internal sealed class ReactNativeModule
    {
        private ReactContext _reactContext;

        [ReactInitializer]
        public void Initialize(ReactContext reactContext)
        {
            _reactContext = reactContext;
        }

        [ReactConstant]
        public JSValue languages
        {
          get
          {
            var jarr = new JSValueArray();
            IReadOnlyList<string> userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;
            foreach (var userLanguage in userLanguages)
            {
              jarr.Add(userLanguage);
            }
            return new JSValue(jarr);
          }
        }

        [ReactMethod("getLanguages")]
        public void GetLanguages(IReactPromise<JSValue> promise)
        {
          var jarr = new JSValueArray();
          IReadOnlyList<string> userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;
          foreach (var userLanguage in userLanguages)
          {
            jarr.Add(userLanguage);
          }
          promise.Resolve(new JSValue(jarr));
        }
    }
}
