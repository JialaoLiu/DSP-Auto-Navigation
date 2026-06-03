# AutoNavigation Current-Version Port

ENG | [中文](AUTO_NAVIGATION_PORT.zh-CN.md)

This repository contains an improved lightweight auto-navigation mod based on
earlier auto-navigation source code by **DarlingZeroX**, updated for a current
Dyson Sphere Program install. Attribution is kept to acknowledge that original
work; the notes below describe this improved build.

Upstream reference: [DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods)

## Behavior

- Press `K` or numpad `0` to toggle auto navigation.
- Set the starmap direction indicator as the target.
- Left Ctrl in the starmap still quick-sets the indicator target.
- `W/A/S/D` still cancels auto navigation or takes manual control.
- During auto navigation, mouse movement is reserved for camera viewing. It no
  longer steers Icarus away from the route.

## Compatibility Changes

- Project references were updated to the local/current DSP managed assemblies.
- Added references to `netstandard.dll` and `UnityEngine.InputLegacyModule.dll`.
- Removed the old post-build event that copied to a hard-coded Steam path and
  launched Steam.
- `ModTranslate.LocalText()` now returns the source text directly because the
  old localization API no longer matches the current game assemblies.

## Sail-Control Adjustment

Current DSP sail mode uses camera-facing input as part of sail physics, so mouse
look can also steer Icarus. This build separates those two concerns during auto
navigation:

- The mod stores an auto-navigation sail rotation internally instead of writing
  it directly into `SailPoser`.
- The sail physics reads `PlayerController.fwdRayUDir`,
  `SailPoser.targetURot`, and `SailPoser.targetURotWanted`; during auto
  navigation those reads are patched to use the auto-navigation direction.
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
SHA256: A914DB3AF4CD178E04C4191AAED3F87790F9EB3474C46D4664584498AF820F83
```
