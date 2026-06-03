# DSP Auto Navigation

ENG | [中文](README.zh-CN.md)

This is an improved lightweight auto-navigation mod for Dyson Sphere Program.
It is based on earlier auto-navigation source code by **DarlingZeroX** and has
been updated for a newer local game build.

## AutoNavigation

Main behavior:

- Set a starmap direction indicator.
- Press `K` or numpad `0` to toggle auto navigation.
- Press `Left Ctrl` over a starmap target to quick-set the indicator.
- Press `W/A/S/D` to cancel auto navigation.

Current notes:

- Built against current local DSP game assemblies.
- Keeps the old lightweight behavior instead of using CruiseAssist/AutoPilot.
- Adjusts current DSP sail input behavior so mouse turning does not take over
  the auto-navigation direction.

See [AUTO_NAVIGATION_PORT.md](AUTO_NAVIGATION_PORT.md) for detailed port notes.
Chinese notes are available at
[AUTO_NAVIGATION_PORT.zh-CN.md](AUTO_NAVIGATION_PORT.zh-CN.md).

## Release DLL

The current built DLL is stored at:

```text
release\AutoNavigation\AutoNavigation.dll
```

Install it to:

```text
Dyson Sphere Program\BepInEx\plugins\AutoNavigation.dll
```

## Attribution

This project is based on earlier auto-navigation source code from
[DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods) by
**DarlingZeroX**. Attribution is kept here to acknowledge that original work.

Compatibility changes, input-behavior adjustments, renaming, and local release
packaging were added on top.
