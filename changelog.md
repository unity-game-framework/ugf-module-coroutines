# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.0.0](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/2.0.0) - 2023-01-03  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/6?closed=1)  
    

### Changed

- Update dependencies ([#15](https://github.com/unity-game-framework/ugf-module-coroutines/issues/15))  
    - Update dependencies: `com.ugf.application` to `8.4.0` and `com.ugf.coroutines` to `1.1.0` versions.
    - Update package _Unity_ version to `2022.2`.
    - Add `CoroutineModuleAsset` class inspector support of replacements for `Executers` collection.

## [2.0.0-preview](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/2.0.0-preview) - 2022-07-14  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/5?closed=1)  
    

### Changed

- Change string ids to global id ([#13](https://github.com/unity-game-framework/ugf-module-coroutines/issues/13))  
    - Update dependencies: `com.ugf.application` to `8.3.0` and `com.ugf.editortools` to `2.8.1` versions.
    - Update package _Unity_ version to `2022.1`.
    - Change usage of ids as `GlobalId` structure instead of `string`.

## [1.0.0](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/1.0.0) - 2022-01-06  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/4?closed=1)  
    

### Added

- Add create default coroutine runner ([#11](https://github.com/unity-game-framework/ugf-module-coroutines/issues/11))  
    - Update dependencies: `com.ugf.application` to `8.0.0` and `com.ugf.coroutines` to `1.0.0` versions.
    - Update package _Unity_ version to `2021.2`.
    - Update package _API Compatibility_ version to `.NET Standard 2.1`.
    - Add `ICoroutineModule.CreateRunnerWithDefaultExecuter()` extension method to create runner with default executer.
    - Change `CoroutineModuleAsset` editor class to make list of executers with selection preview.

## [1.0.0-preview](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/1.0.0-preview) - 2021-05-26  

### Release Notes

- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/3?closed=1)  
    

### Changed

- Update dependencies to use executer initialization ([#10](https://github.com/unity-game-framework/ugf-module-coroutines/pull/10))  
    - Update dependencies: `com.ugf.coroutines` to `1.0.0-preview.1` version.
    - Add `CoroutineExecuterGameObjectAsset` to create `CoroutineExecuterGameObject` executer.
    - Add `CoroutineModule` initialize and uninitialize logs.
    - Change `CoroutineModule` to initialize and uninitialize created executers.
    - Remove `CoroutineExecuterUnityAsset` class, replaced by `CoroutineExecuterGameObjectAsset`.
- Update application dependency package ([#8](https://github.com/unity-game-framework/ugf-module-coroutines/pull/8))  
    - Update project to Unity `2021.1` version.
    - Update dependencies: `com.ugf.application` to `8.0.0-preview.7` and `com.ugf.coroutines` to `1.0.0-preview`.
    - Update package publish registry.
    - Add `ICoroutineExecuterBuilder` interface and `CoroutineExecuterAsset` class as default implementation.
    - Add `CoroutineExecuterUnityAsset` class to build `CoroutineExecuterUnity` executer class.
    - Rework `CoroutineModule`, `CoroutineModuleDescription ` and `CoroutineModuleAsset` module classes.
- Update project workflows ([#5](https://github.com/unity-game-framework/ugf-module-coroutines/issues/5))  
    - Update project workflows.

## [0.2.0-preview](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/0.2.0-preview) - 2019-12-09  

- [Commits](https://github.com/unity-game-framework/ugf-module-coroutines/compare/0.1.0-preview...0.2.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/2?closed=1)

### Added
- Package dependencies:
    - `com.ugf.application`: `3.0.0-preview`.

### Changed
- Update `UGF.Application` package.

### Removed
- Package dependencies:
    - `com.ugf.module`: `0.2.0-preview`.

## [0.1.0-preview](https://github.com/unity-game-framework/ugf-module-coroutines/releases/tag/0.1.0-preview) - 2019-10-10  

- [Commits](https://github.com/unity-game-framework/ugf-module-coroutines/compare/b36632a...0.1.0-preview)
- [Milestone](https://github.com/unity-game-framework/ugf-module-coroutines/milestone/1?closed=1)

### Added
- This is a initial release.


