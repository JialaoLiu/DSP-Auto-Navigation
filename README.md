# DSP Auto Navigation

ENG | [中文](README.zh-CN.md)

An improved lightweight auto-navigation mod for Dyson Sphere Program. It is
based on earlier auto-navigation source code by **DarlingZeroX** and updated for
newer DSP builds.

## Features

- Set a starmap direction indicator as the destination.
- Press `K` or numpad `0` to toggle auto navigation.
- Press `Left Ctrl` over a starmap target to quick-set the indicator.
- Press `W/A/S/D` to cancel auto navigation or take manual control.
- Supports navigation to Dark Fog hives through starmap direction indicators.
- During auto navigation, mouse movement controls the camera only. It no longer
  steers Icarus away from the route.

## What Changed

Project and compatibility changes:

- Renamed the mod from the old Stellar naming to `AutoNavigation`.
- Built against current local DSP game assemblies.
- Added references to `netstandard.dll` and `UnityEngine.InputLegacyModule.dll`.
- Removed the old post-build event that copied to a hard-coded Steam path and
  launched Steam.
- `ModTranslate.LocalText()` now returns the source text directly because the
  old localization API no longer matches current game assemblies.

Sail-control changes for current DSP:

- Current DSP sail mode uses camera-facing input as part of sail physics, so
  mouse look can also steer Icarus.
- Dark Fog hive targets are resolved from the game's own starmap indicator
  astro id and navigated with the hive astro position.
- This build stores an internal auto-navigation sail direction instead of
  directly writing it into the camera-linked `SailPoser` state.
- During auto navigation, sail physics reads of `PlayerController.fwdRayUDir`,
  `SailPoser.targetURot`, and `SailPoser.targetURotWanted` are patched to use
  the auto-navigation direction.
- The actual camera state remains free to follow mouse movement.

## Build

Open `DspMods.sln` or build:

```powershell
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" `
  .\AutoNavigation\AutoNavigation.csproj `
  /p:Configuration=Release `
  /p:Platform=AnyCPU
```

If the .NET Framework 4.7.2 targeting pack is unavailable, pass a
`FrameworkPathOverride` that points at a local reference-assemblies package.

## Install

Install BepInEx for Dyson Sphere Program, then copy:

```text
release\AutoNavigation\AutoNavigation.dll
```

to:

```text
Dyson Sphere Program\BepInEx\plugins\AutoNavigation.dll
```

Current release DLL:

```text
SHA256: 396B020737FC6E238C23B9A20935FDFEB744D2C506134320E03B430ECD795F0C
```

## Attribution

This project is based on earlier auto-navigation source code from
[DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods) by
**DarlingZeroX**. Attribution is kept here to acknowledge that original work.

Compatibility changes, input-behavior adjustments, renaming, and local release
packaging were added on top.
