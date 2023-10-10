const project = (() => {
  const fs = require("fs");
  const path = require("path");
  try {
    const {
      androidManifestPath,
      windowsProjectPath,
    } = require("react-native-test-app");
    return {
      android: {
        sourceDir: path.join("example", "android"),
        manifestPath: androidManifestPath(
          path.join(__dirname, "example", "android")
        ),
      },
      ios: {
        sourceDir: "example/ios",
      },
      windows: fs.existsSync("example/windows/Example.sln") && {
        sourceDir: path.join("example", "windows"),
        solutionFile: "Example.sln",
        project: windowsProjectPath(path.join(__dirname, "example", "windows")),
      },
    };
  } catch (_) {
    return undefined;
  }
})();

module.exports = {
  dependencies: {
    // Help rn-cli find and autolink this library
    "@axsy-dev/react-native-i18n": {
      root: __dirname,
    },
  },
  dependency: {
    platforms: {
      windows: {
        sourceDir: "windows",
        solutionFile: "AxsyDevReactNativeI18N.sln",
        projects: [
          {
            projectFile: "AxsyDevReactNativeI18N/AxsyDevReactNativeI18N.csproj",
            directDependency: true,
          },
        ],
      },
    },
  },
  ...(project ? { project } : undefined),
};
