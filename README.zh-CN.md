﻿﻿﻿﻿<p align="center">
  <a href="https://masa-blazor-docs-dev.lonsid.cn" target="_blank">
    <img alt="MASA Blazor Pro Logo" width="150" src="./imgs/logo.png">
  </a>
</p>

<h1 align="center">MASA Blazor Pro</h1>

<div align="center">

开箱即用的中台前端/设计解决方案，Blazor 项目模板，提供多种常见场景的预设布局。

[![MASA.Blazor.Pro](https://img.shields.io/badge/license-MIT-informational)](https://github.com/BlazorComponent/MASA.Blazor.Pro/blob/develop/LICENSE) 



[English](./README.md) | 简体中文

## 在线示例

[https://masa-blazor-pro.lonsid.cn](https://masa-blazor-pro.lonsid.cn "https://masa-blazor-pro.lonsid.cn")

## 模板

```
- Dashboards
  - 商务报表
  - 分析报表
- Apps
  - 商城
  - 工作事项
  - 发票
  - 用户
- Pages
  - 登录
  - 注册
  - 忘记密码
  - 重置密码
  - 账户设置
  - 500
  - 401 
```

## 使用

在 `wwwroot/index.html`(WebAssembly) 或 `Pages/_Host.cshtml`(Server) 中引入样式:

```html
<html lang="en">
	<head>
		<!--Style-->
		<link href="css/masa-blazor-pro.css" rel="stylesheet">
		<!--<link href="{ASSEMBLY NAME}.styles.css" rel="stylesheet">-->
		<link href="MASA.Blazor.Pro.styles.css" rel="stylesheet">
	</head>
</html>
```
> `masa-blazor-pro.css`文件在项目wwwroot/css/masa-blazor-pro.css层级目录下

> `MASA.Blazor.Pro.styles.css`需要改为`{ASSEMBLY NAME}.styles.css`,占位符 `{ASSEMBLY NAME}` 是项目的程序集名称,详情请见 [ASP.NET Core Blazor CSS 隔离](https://docs.microsoft.com/zh-cn/aspnet/core/blazor/components/css-isolation?view=aspnetcore-6.0)

## 相关项目

- [BlazorComponent（无样式的底层组件框架)](https://github.com/BlazorComponent/BlazorComponent)
- [MASA Blazor（一套基于Material设计规范和BlazorComponent的交互能力提供标准的基础组件库)](https://github.com/BlazorComponent/MASA.Blazor)

## 浏览器支持

![chrome](https://img.shields.io/badge/chrome->%3D57-success.svg?logo=google%20chrome&logoColor=red)![firefox](https://img.shields.io/badge/firefox->522-success.svg?logo=mozilla%20firefox&logoColor=red)![edge](https://img.shields.io/badge/edge->%3D16-success.svg?logo=microsoft%20edge&logoColor=blue)![ie](https://img.shields.io/badge/ie->%3D11-success.svg?logo=internet%20explorer&logoColor=blue)![Safari](https://img.shields.io/badge/safari->%3D14-success.svg?logo=safari&logoColor=blue)![oper](https://img.shields.io/badge/opera->%3D4.4-success.svg?logo=opera&logoColor=red)

### 移动设备

![ios](https://img.shields.io/badge/ios-supported-success.svg?logo=apple&logoColor=white)![Andriod](https://img.shields.io/badge/andriod-suported-success.svg?logo=android)

|         |  Chrome     |  Firefox     |  Safari     | Microsoft Edge |
| ------- | ---------   | ---------    | ------      | -------------- |
| iOS     | Supported   | Supported    | Supported   | Supported      |
| Android | Supported   | Supported    | N/A         | Supported      |

### 桌面设备

![macOS](https://img.shields.io/badge/macOS-supported-success.svg?logo=apple&logoColor=white)![linux](https://img.shields.io/badge/linux-suported-success.svg?logo=linux&logoColor=white)![windows](https://img.shields.io/badge/windows-suported-success.svg?logo=windows)

|         | Chrome    | Firefox   | Safari        | Opera     | Microsoft Edge | Internet Explorer |
| ------- | --------- | --------- | ------------- | --------- | -------------- | ----------------- |
| Mac     | Supported | Supported | Supported     | Supported | N/A            | N/A               |
| Linux   | Supported | Supported | N/A           | N/A       | N/A            | N/A               |
| Windows | Supported | Supported | Not supported | Supported | Supported      | Supported, IE11+  |

> 由于 [WebAssembly](https://webassembly.org) 的限制，Blazor WebAssembly 不支持 IE 浏览器，但 Blazor Server 支持 IE 11†。 详见[官网说明](https://docs.microsoft.com/zh-cn/aspnet/core/blazor/supported-platforms?view=aspnetcore-3.1&WT.mc_id=DT-MVP-5003987)。

## 如何贡献

1. Clone
2. Create Feature_xxx branch
3. Commit with commit message, like `feat:add MButton`
4. Create Pull Request

如果你希望参与贡献，欢迎 [Pull Request](https://github.com/BlazorComponent/MASA.Blazor.Pro/pulls)，或给我们 [报告 Bug](https://github.com/BlazorComponent/MASA.Blazor.Pro/issues/new) 。

### 贡献者

感谢所有为本项目做出过贡献的朋友。

<a href="https://github.com/BlazorComponent/MASA.Blazor.Pro/graphs/contributors"> 
    <img src="https://contrib.rocks/image?repo=BlazorComponent/MASA.Blazor.Pro" /> 
</a>

## 交流

QQ群 | 微信群 | 微信公众号 | 微信客服
:---:|:---:|:---:|:---:
![masa.blazor-qq](./imgs/masa.blazor-qq-group.png) | ![masa.blazor-weixin](./imgs/masa.blazor-wechat-group.png) | ![masa.blazor-weixin](./imgs/masa.blazor-wechat-public-account.png) | ![masa.blazor-weixin](./imgs/masa.blazor-wechat-customer-service.png)


## 开发团队

数闪技术团队，是一支高效，稳定，创新的团队。团队秉承着丰富Blazor生态的初心，去不断努力，为开发人员带来更好的体验是数闪技术团队的追求。感谢各位的支持和使用。

## 行为准则

本项目采用了《贡献者公约》所定义的行为准则，以明确我们社区的预期行为。更多信息请见 [.NET Foundation Code of Conduct](https://dotnetfoundation.org/code-of-conduct).

## 许可声明

[![MASABlazor](https://img.shields.io/badge/license-MIT-informational)](https://github.com/BlazorComponent/MASA.Blazor.Pro/blob/develop/LICENSE) 

Copyright (c) 2021-present MASA.Blazor.Pro