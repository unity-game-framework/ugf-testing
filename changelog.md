# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0-preview.2](https://github.com/unity-game-framework/ugf-testing/releases/tag/1.0.0-preview.2) - 2021-08-07  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/6?closed=1)  
    

### Changed

- Change preview assetbundle info to update only when required ([#14](https://github.com/unity-game-framework/ugf-testing/pull/14))  
    - Update dependencies: `com.ugf.assetbundles` to `1.0.0-preview.1` version.
    - Change _Test Resources Editor settings AssetBundle Information_ update only when required.

## [1.0.0-preview.1](https://github.com/unity-game-framework/ugf-testing/releases/tag/1.0.0-preview.1) - 2021-08-07  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/5?closed=1)  
    

### Removed

- Remove TestBase class ([#12](https://github.com/unity-game-framework/ugf-testing/pull/12))  
    - Remove `TestBase` and `TestNoLogs ` classes, usage of this classes not possible as imported code from remote package.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-testing/releases/tag/1.0.0-preview) - 2021-08-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/4?closed=1)  
    

### Added

- Add test resources management ([#10](https://github.com/unity-game-framework/ugf-testing/pull/10))  
    - Update dependencies: add `com.ugf.customsettings` of `3.4.1` version and `com.ugf.assetbundles` of `1.0.0-preview` version.
    - Add `TestResourcesProvider` class to access to _AssetBundle_ with testing resources during runtime tests.
    - Add _Test Resources_ runtime settings to specify settings for _AssetBundle_ loading for runtime tests.
    - Add _Test Resources Editor_ editor settings to specify what resources to build as _AssetBundle_ which used during tests.
    - Add `TestResourcesEditorUtility` class to manage _AssetBundle_ for testing resources in editor.

### Changed

- Update package to Unity 2021.1 ([#9](https://github.com/unity-game-framework/ugf-testing/pull/9))  
    - Update package _Unity_ version to `2021.1`.
    - Update dependencies: `com.unity.test-framework` to `1.1.27` version.
    - Change namespace of the runtime assembly to `UGF.Testings.Runtime`.
    - Change location of all scope classes under the _Scope_ folder and update namespaces.
    - Change assembly definition to be included only in build with tests.
    - Change name of `TestLogScope` scope structure to `TestLogEnableScope`.
    - Change name of all setup and teardown methods of `TestBase` class to `OnSetupAll`, `OnTeardownAll`, `OnSetup` and `OnTeardown`.

## [0.2.0-preview](https://github.com/unity-game-framework/ugf-testing/releases/tag/0.2.0-preview) - 2019-10-20  

- [Commits](https://github.com/unity-game-framework/ugf-testing/compare/0.1.1-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/3?closed=1)

### Added
- `TestBase` with default methods such as `SetupAll`, `TeardownAll`, `Setup` and `Teardown`.

### Removed
- `TestTestCollectLogs`.

## [0.1.1-preview](https://github.com/unity-game-framework/ugf-testing/releases/tag/0.1.1-preview) - 2019-09-23  

- [Commits](https://github.com/unity-game-framework/ugf-testing/compare/0.1.0-preview...0.1.1-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/2?closed=1)

### Fixed
- `UGF.Testing.Runtime.Tests` assembly definition to be available as reference.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-testing/releases/tag/0.1.0-preview) - 2019-09-23  

- [Commits](https://github.com/unity-game-framework/ugf-testing/compare/ec13da6...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-testing/milestone/1?closed=1)

### Added
- This is a initial release.


