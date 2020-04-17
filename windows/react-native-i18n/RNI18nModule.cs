using Microsoft.ReactNative.Managed;
using System;
using System.Collections.Generic;


namespace react_native_i18n
{
  [ReactModule("RNI18n")]
  public sealed class RNI18nModule
  {

    [ReactConstant]
    JSValue languages
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
    void GetLanguages(IReactPromise<JSValueArray> promise)
    {

      var jarr = new JSValueArray();
      IReadOnlyList<string> userLanguages = Windows.System.UserProfile.GlobalizationPreferences.Languages;
      foreach (var userLanguage in userLanguages)
      {
        jarr.Add(userLanguage);
      }
      promise.Resolve(jarr);
    }

  }
}
