# DSP Auto Navigation

[ENG](README.md) | 中文

这是一个《戴森球计划》轻量自动航行 Mod。项目基于 **DarlingZeroX** 早期自动航行源码改良，并适配到较新的本机游戏版本。

## AutoNavigation

主要用法：

- 在星图里设置方位指示。
- 按 `K` 或小键盘 `0` 开启/关闭自动航行。
- 在星图里把鼠标放到目标上，按 `Left Ctrl` 可以快速设置导航标识。
- 按 `W/A/S/D` 取消自动航行或手动接管。
- 自动航行期间，鼠标只用于转动相机看风景，不再控制伊卡洛斯偏离自动航线。

当前版本说明：

- 使用当前本机 DSP 游戏程序集重新编译。
- 保留老版轻量手感，不使用 CruiseAssist/AutoPilot 那套额外窗口和功能。
- 针对当前版本 DSP，将相机观看方向和航行物理方向分离。

详细适配说明见：[AUTO_NAVIGATION_PORT.zh-CN.md](AUTO_NAVIGATION_PORT.zh-CN.md)

英文适配说明见：[AUTO_NAVIGATION_PORT.md](AUTO_NAVIGATION_PORT.md)

## Release DLL

当前构建好的 DLL 存放在：

```text
release\AutoNavigation\AutoNavigation.dll
```

安装到：

```text
Dyson Sphere Program\BepInEx\plugins\AutoNavigation.dll
```

## 署名

本项目基于 [DarlingZeroX/DspMods](https://github.com/DarlingZeroX/DspMods) 中由 **DarlingZeroX** 编写的早期自动航行源码。这里保留署名，用于感谢和标明原始代码来源。

当前版本在此基础上加入了兼容性修改、输入手感调整、重命名和本地 release 打包。
