using Newtonsoft.Json.Linq;
using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNI18n
{
    public class RNI18nModule : ReactContextNativeModuleBase
    {
        public RNI18nModule(ReactContext reactContext) : base(reactContext)
        {
        }

        public override string Name => "RNI18n";

        public override IReadOnlyDictionary<string, object> Constants
        {
            get
            {
                return new Dictionary<string, object>
                {
                    { "languages", Windows.System.UserProfile.GlobalizationPreferences.Languages }
                };
            }
        }

        [ReactMethod]
        public void getLanguages(IPromise promise)
        {
            var jarr = new JArray();
            IReadOnlyList<string> userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;
            foreach (var userLanguage in userLanguages)
            {
                jarr.Add(userLanguage);
            }
            promise.Resolve(jarr);
        }
    }
}
