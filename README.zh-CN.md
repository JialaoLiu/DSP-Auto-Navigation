# DSP Auto Navigation

[ENG](README.md) | 中文

这是一个《戴森球计划》轻量自动航行 Mod。项目基于 **DarlingZeroX** 早期自动航行源码改良，并适配到较新的 DSP 版本。

## 功能

- 在星图里设置方位指示作为目的地。
- 按 `K` 或小键盘 `0` 开启/关闭自动航行。
- 在星图里把鼠标放到目标上，按 `Left Ctrl` 可以快速设置导航标识。
- 按 `W/A/S/D` 取消自动航行或手动接管。
- 支持通过星图方位指示导航到黑雾巢穴。
- 自动航行期间，鼠标只用于转动相机看风景，不再控制伊卡洛斯偏离自动航线。

## 改动内容

项目和兼容性修改：

- 将旧的 Stellar 命名改为 `AutoNavigation`。
- 使用当前本机 DSP 游戏程序集重新编译。
- 新增 `netstandard.dll` 和 `UnityEngine.InputLegacyModule.dll` 引用。
- 移除了旧的 post-build event，原事件会把 DLL 复制到写死的 Steam 路径并启动 Steam。
- `ModTranslate.LocalText()` 现在直接返回原文本，因为旧版本地化 API 已经与当前游戏程序集不兼容。

当前 DSP 航行控制修正：

- 当前版本 DSP 的航行模式会把相机朝向输入作为航行物理的一部分，所以鼠标看向哪里也会影响伊卡洛斯飞向哪里。
- 黑雾巢穴目标会从游戏原版星图方位指示的 astro id 反查，并使用巢穴 astro 坐标进行导航。
- 当前版本内部保存一份自动航行用的航向，不再直接写死和相机绑定的 `SailPoser` 状态。
- 自动航行期间，航行物理读取 `PlayerController.fwdRayUDir`、`SailPoser.targetURot`、`SailPoser.targetURotWanted` 时，会被替换成自动航行方向。
- 实际相机状态仍然可以跟随鼠标自由转动。

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
SHA256: 335F9DFBA12A0ACFEB01BD099D52118697C397919B77F227514EA86E8E27D44E
```

## 署名

本项目基于 [DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods) 中由 **DarlingZeroX** 编写的早期自动航行源码。这里保留署名，用于感谢和标明原始代码来源。

当前版本在此基础上加入了兼容性修改、输入手感调整、重命名和本地 release 打包。
