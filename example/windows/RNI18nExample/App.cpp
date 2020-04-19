#include "pch.h"

#include "App.h"
#include "ReactPackageProvider.h"
#include "winrt/react_native_i18n.h"



using namespace winrt::RNI18nExample;
using namespace winrt::RNI18nExample::implementation;

/// <summary>
/// Initializes the singleton application object.  This is the first line of
/// authored code executed, and as such is the logical equivalent of main() or
/// WinMain().
/// </summary>
App::App() noexcept
{
    MainComponentName(L"RNI18nExample");

#if BUNDLE
    JavaScriptBundleFile(L"index.windows");
    InstanceSettings().UseWebDebugger(false);
    InstanceSettings().UseFastRefresh(false);
#else
    JavaScriptMainModuleName(L"index");
    InstanceSettings().UseWebDebugger(true);
    InstanceSettings().UseFastRefresh(true);
#endif

#if _DEBUG
    InstanceSettings().EnableDeveloperMenu(true);
#else
    InstanceSettings().EnableDeveloperMenu(false);
#endif
    
    PackageProviders().Append(make<ReactPackageProvider>()); // Includes all modules in this project
    PackageProviders().Append(winrt::react_native_i18n::ReactPackageProvider());

    REACT_REGISTER_NATIVE_MODULE_PACKAGES(); //code-gen macro from autolink

    InitializeComponent();

    // This works around a cpp/winrt bug with composable/aggregable types tracked
    // by 22116519
    AddRef();
    m_inner.as<::IUnknown>()->Release();
}


