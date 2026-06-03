# AutoNavigation 当前版本适配说明

[ENG](AUTO_NAVIGATION_PORT.md) | 中文

这个仓库包含一个改良后的轻量自动航行 Mod，基于 **DarlingZeroX** 早期自动航行源码，并适配到当前《戴森球计划》版本。这里保留署名用于感谢和标明原始代码来源；下方记录的是当前改良版的兼容性修改和打包方式。

参考来源：[DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods)

## 行为说明

- 按 `K` 或小键盘 `0` 开启/关闭自动航行。
- 使用星图方位指示作为目标。
- 星图中按 `Left Ctrl` 仍可快速设置目标方位指示。
- `W/A/S/D` 仍会取消自动航行或手动接管。
- 自动航行期间，鼠标只用于转动相机看风景，不再控制伊卡洛斯偏离自动航线。

## 兼容性修改

- 将项目引用改到当前本机 DSP 游戏程序集。
- 新增 `netstandard.dll` 和 `UnityEngine.InputLegacyModule.dll` 引用。
- 移除了旧的 post-build event，原事件会把 DLL 复制到写死的 Steam 路径并启动 Steam。
- `ModTranslate.LocalText()` 现在直接返回原文本，因为旧版本地化 API 已经与当前游戏程序集不兼容。

## 航行控制修正

当前版本 DSP 的航行模式会把相机朝向输入作为航行物理的一部分，所以鼠标看向哪里也会影响伊卡洛斯飞向哪里。当前版本在自动航行期间将两者分离：

- Mod 内部保存一份自动航行用的航向，不再直接写死 `SailPoser` 的相机状态。
- 航行物理会读取 `PlayerController.fwdRayUDir`、`SailPoser.targetURot` 和 `SailPoser.targetURotWanted`；自动航行期间，这些读取会被替换成自动航行方向。
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
SHA256: A914DB3AF4CD178E04C4191AAED3F87790F9EB3474C46D4664584498AF820F83
```
