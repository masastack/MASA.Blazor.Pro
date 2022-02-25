﻿﻿﻿﻿﻿﻿﻿﻿﻿<p align="center">
  <a href="https://masa-blazor-docs-dev.lonsid.cn" target="_blank">
    <img alt="Masa Blazor Pro Logo" width="150" src="./imgs/logo.png">
  </a>
</p>

<h1 align="center">Masa Blazor Pro</h1>

<div align="center">

开箱即用的中台前端/设计解决方案，Blazor 项目模板，提供多种常见场景的预设布局。

[![Masa.Blazor.Pro](https://img.shields.io/badge/license-MIT-informational)](https://github.com/BlazorComponent/Masa.Blazor.Pro/blob/develop/LICENSE) 

</div>

[English](./README.md) | 简体中文

## 在线示例

[https://masa-blazor-pro.lonsid.cn](https://masa-blazor-pro.lonsid.cn "https://masa-blazor-pro.lonsid.cn")

## 模板

```
- Dashboard
  - 电商报表
- App
  - 商城
  - 工作事项
  - 发票
  - 用户
- Page
  - 登录
  - 注册
  - 忘记密码
  - 重置密码
  - 账户设置
  - 500
  - 401 
```

## 使用

* [CLI](#CLI)
* [现有项目](#现有项目)

### CLI

**安装模板**

```shell
dotnet new --install Masa.Template
```

**创建项目**

* Blazor Server

```shell
dotnet new masabp -o Masa.Test
```

- Blazor WebAssembly

```shell
dotnet new masabp --mode Wasm -o Masa.TestWasm
```

- Blazor RCL

```shell
dotnet new masabp --mode ServerAndWasm -o Masa.TestRcl
```

**进入Server项目目录**

```shell
cd Masa.Test
```

**运行**

```shell
dotnet run
```



![masabp](imgs/masabp.gif)



### 现有项目

- 在 `wwwroot/index.html`(WebAssembly) 或 `Pages/_Host.cshtml`(Server) 中引入样式:

```html
<html lang="en">
	<head>
		<!--Style-->
		<link href="css/masa-blazor-pro.css" rel="stylesheet">
		<!--<link href="{ASSEMBLY NAME}.styles.css" rel="stylesheet">-->
		<link href="Masa.Blazor.Pro.styles.css" rel="stylesheet">
	</head>
</html>
```

> `masa-blazor-pro.css`文件在项目wwwroot/css/masa-blazor-pro.css层级目录下

> `Masa.Blazor.Pro.styles.css`需要改为`{ASSEMBLY NAME}.styles.css`,占位符 `{ASSEMBLY NAME}` 是项目的程序集名称,详情请见 [ASP.NET Core Blazor CSS 隔离](https://docs.microsoft.com/zh-cn/aspnet/core/blazor/components/css-isolation?view=aspnetcore-6.0)

- 设置MasaBlazor主题

```c#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMasaBlazor(builder => 
{
    builder.UseTheme(option=>
        {
            option.Primary = "#4318FF";
            option.Accent = "#4318FF";
        }
    );
});
```
## 效果展示

|效果图|效果图|
| :-----------: | :-----------: |
|![dashboard](./imgs/dashboard.png)|![basket](./imgs/basket.png)|
|![edit](./imgs/edit.png)|![view](./imgs/view.png)|
|![login](./imgs/login.png)|![todo](./imgs/todo.png)|

## 相关项目

- [BlazorComponent（无样式的底层组件框架)](https://github.com/BlazorComponent/BlazorComponent)
- [Masa Blazor（一套基于Material设计规范和BlazorComponent的交互能力提供标准的基础组件库)](https://github.com/BlazorComponent/Masa.Blazor)

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

如果你希望参与贡献，欢迎 [Pull Request](https://github.com/BlazorComponent/Masa.Blazor.Pro/pulls)，或给我们 [报告 Bug](https://github.com/BlazorComponent/Masa.Blazor.Pro/issues/new) 。

### 贡献者

感谢所有为本项目做出过贡献的朋友。

<a href="https://github.com/BlazorComponent/Masa.Blazor.Pro/graphs/contributors"> 
    <img src="https://contrib.rocks/image?repo=BlazorComponent/Masa.Blazor.Pro" /> 
</a>

## 交流

QQ群 | 微信公众号 | 微信客服
:---:|:---:|:---:
![masa.blazor-qq](./imgs/masa.blazor-qq-group.png) | ![masa.blazor-weixin](./imgs/masa.blazor-wechat-public-account.png) | ![masa.blazor-weixin](./imgs/masa.blazor-wechat-customer-service.png)


## 开发团队

数闪技术团队，是一支高效，稳定，创新的团队。团队秉承着丰富Blazor生态的初心，去不断努力，为开发人员带来更好的体验是数闪技术团队的追求。感谢各位的支持和使用。

## 行为准则

本项目采用了《贡献者公约》所定义的行为准则，以明确我们社区的预期行为。更多信息请见 [Masa Stack Community Code of Conduct](https://github.com/masastack/community/blob/main/CODE-OF-CONDUCT.md).

## 许可声明

[![Masa.Blazor.Pro](https://img.shields.io/badge/license-MIT-informational)](https://github.com/BlazorComponent/Masa.Blazor.Pro/blob/develop/LICENSE) 

Copyright (c) 2021-present Masa.Blazor.Pro