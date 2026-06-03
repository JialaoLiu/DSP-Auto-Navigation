# AutoNavigation Current-Version Port

ENG | [中文](AUTO_NAVIGATION_PORT.zh-CN.md)

This repository contains an improved lightweight auto-navigation mod based on
earlier auto-navigation source code by **DarlingZeroX**, updated for a current
Dyson Sphere Program install. Attribution is kept to acknowledge that original
work; the notes below describe this improved build.

Upstream reference: [DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods)

Tested game path:

```text
E:\Game\Steam\steamapps\common\Dyson Sphere Program
```

Built against:

- `DSPGAME_Data\Managed\Assembly-CSharp.dll`
- `DSPGAME_Data\Managed\netstandard.dll`
- Unity managed assemblies from the same game install
- BepInEx 5.4.17

## What Changed

The navigation behavior is intentionally kept small and close to the lightweight
old feel:

- Press `K` or numpad `0` to toggle auto navigation.
- Set the starmap direction indicator as the target.
- Left Ctrl in the starmap still quick-sets the indicator target.
- `W/A/S/D` still cancels auto navigation.

Compatibility changes:

- Project references were updated to the local/current DSP managed assemblies.
- Added references to `netstandard.dll` and `UnityEngine.InputLegacyModule.dll`.
- Removed the old post-build event that copied to a hard-coded Steam path and
  launched Steam.
- `ModTranslate.LocalText()` now returns the source text directly because the
  old localization API no longer matches the current game assemblies.

Sail-control adjustment for current DSP:

- Current `PlayerMove_Sail.GameTick` applies `controller.input1.x` to
  `sailPoser.targetURotWanted`, which lets mouse/turn input affect auto
  navigation.
- During auto navigation, this build temporarily clears `controller.input1.x`
  while the original sail tick runs, then restores it afterward.
- `Sail.SetDir()` now writes both `targetURot` and `targetURotWanted`, matching
  the current game's two-stage sail rotation state.

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
SHA256: 5DE3EFF5F17880FD1FB36C285C83EEE24309872EB1906EDF2CAD86F63619B3D0
```

