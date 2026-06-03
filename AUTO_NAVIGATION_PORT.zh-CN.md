# AutoNavigation 当前版本适配说明

[ENG](AUTO_NAVIGATION_PORT.md) | 中文

这个仓库包含一个改良后的轻量自动航行 Mod，基于 **DarlingZeroX** 早期自动航行源码，并适配到当前《戴森球计划》版本。这里保留署名用于感谢和标明原始代码来源；下方记录的是当前改良版的兼容性修改和打包方式。

参考来源：[DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods)

测试用游戏路径：

```text
E:\Game\Steam\steamapps\common\Dyson Sphere Program
```

构建时引用：

- `DSPGAME_Data\Managed\Assembly-CSharp.dll`
- `DSPGAME_Data\Managed\netstandard.dll`
- 同一个游戏目录下的 Unity managed assemblies
- BepInEx 5.4.17

## 改动内容

自动航行行为尽量保持轻量、接近老手感：

- 按 `K` 或小键盘 `0` 开启/关闭自动航行。
- 使用星图方位指示作为目标。
- 星图中按 `Left Ctrl` 仍可快速设置目标方位指示。
- `W/A/S/D` 仍会取消自动航行。

兼容性修改：

- 将项目引用改到当前本机 DSP 游戏程序集。
- 新增 `netstandard.dll` 和 `UnityEngine.InputLegacyModule.dll` 引用。
- 移除了旧的 post-build event，原事件会把 DLL 复制到写死的 Steam 路径并启动 Steam。
- `ModTranslate.LocalText()` 现在直接返回原文本，因为旧版本地化 API 已经与当前游戏程序集不兼容。

当前 DSP 航行控制修正：

- 当前版本的 `PlayerMove_Sail.GameTick` 会把 `controller.input1.x` 应用到 `sailPoser.targetURotWanted`，这会让鼠标/转向输入影响自动航行方向。
- 自动航行期间，本版本会在原版 sail tick 执行时临时清空 `controller.input1.x`，执行结束后再恢复。
- `Sail.SetDir()` 现在同时写入 `targetURot` 和 `targetURotWanted`，以匹配当前游戏的两阶段航行旋转状态。

## 构建

可以打开 `DspMods.sln`，或用 MSBuild：

```powershell
& "C:\Program Files (x86)\Microsoft Visual Studio\2019\BuildTools\MSBuild\Current\Bin\MSBuild.exe" `
  .\AutoNavigation\AutoNavigation.csproj `
  /p:Configuration=Release `
  /p:Platform=AnyCPU
```

如果本机没有 .NET Framework 4.7.2 Targeting Pack，可以额外传入 `FrameworkPathOverride`，指向本地 reference assemblies 包。

## 安装

先给《戴森球计划》安装 BepInEx，然后复制：

```text
release\AutoNavigation\AutoNavigation.dll
```

到：

```text
Dyson Sphere Program\BepInEx\plugins\AutoNavigation.dll
```

当前 release DLL：

```text
SHA256: 5DE3EFF5F17880FD1FB36C285C83EEE24309872EB1906EDF2CAD86F63619B3D0
```

