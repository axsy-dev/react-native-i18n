using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactNative.Bridge;
using ReactNative.Modules.Core;
using ReactNative.UIManager;

namespace RNI18n
{
    public class RNI18nPackage : IReactPackage
    {
        /// <summary>
        /// Creates the list of native modules to register with the react
        /// instance.
        /// </summary>
        /// <param name="reactContext">The react application context.</param>
        /// <returns>The list of native modules.</returns>
        public IReadOnlyList<INativeModule> CreateNativeModules(ReactContext reactContext)
        {
            return new List<INativeModule>
            {
                new RNI18nModule(reactContext),
            };
        }

        /// <summary>
        /// Creates the list of JavaScript modules to register with the
        /// react instance.
        /// </summary>
        /// <returns>The list of JavaScript modules.</returns>
        public IReadOnlyList<Type> CreateJavaScriptModulesConfig()
        {
            return new List<Type>(0);
        }

        /// <summary>
        /// Creates the list of view managers that should be registered with
        /// the <see cref="UIManagerModule"/>.
        /// </summary>
        /// <param name="reactContext">The react application context.</param>
        /// <returns>The list of view managers.</returns>
        public IReadOnlyList<IViewManager> CreateViewManagers(
            ReactContext reactContext)
        {
            return new List<IViewManager>(0);
        }
    }
}
