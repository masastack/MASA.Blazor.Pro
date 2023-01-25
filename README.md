# README.md

[English](./README.en-US.md) | [简体中文](./README.zh-CN.md)

# Learn Notes

> [BlazorComponent/MASA.Blazor: Blazor component library based on Material Design. Support Blazor Server and Blazor WebAssembly. (github.com)](https://github.com/BlazorComponent/MASA.Blazor)
>
> [BlazorComponent/BlazorComponent: There is no style blazor component library. (github.com)](https://github.com/BlazorComponent/BlazorComponent)

## Prepare

1. Fork 以上两个仓库
2. Git Clone {Fork后的 MASA.Blazor 项目}
3. cd 到 {MASA.Blazor\src} 目录
   1. Git Clone {Fork后的 BlazorComponent 项目}
4. 打开 MASA.Blazor.sln 解决方案

## Solution

| 目录      | 描述           |
| --------- | -------------- |
| Test      | 单元测试       |
| Component | 组件           |
| CLI       | 生成文档的工具 |
| Doc       | 文档站点项目   |

# Projects

## BlazorComponent

仅提供功能和接口。

## MASA.Blazor

继承于 BlazorComponent 项目，为功能和接口提供样式。

## Guide

MASA.Blazor 项目内的 Mxxx 组件应继承于 Bxxx 组件。

Bxxx 组件提供功能和接口，作为组件的基础。

Mxxx 组件为 Bxxx 组件提供 MaterialDesign 风格的样式，作为组件的装饰，并可以被替代。

Mxxx 组件使用 `protected override void SetComponentClass()` 方法设置组件各个部分的样式。

## Structure

### BlazorComponent

- `IICon.cs`
  - 功能接口
- `BIcon.razor`
  - 设计组件的 DOM 结构
  - 使用 `@RenderPart(typeof(BFontIconSlot<>))` 渲染插槽所在DOM结构的位置
- `BFontIconSlot<TIcon>.razor` where `TIcon : IIcon`
  - 渲染插槽组件

### MASA.Balzor

- `MIcon.cs` : `BIcon, IICon`
  - 在 `SetComponentClass()` 方法中设置组件的 DOM 元素的样式
  - 在 `SetComponentClass()` 方法中调用 `AbstractProvider.Apply(typeof(BFontIconSlot<>), typeof(BFontIconSlot<MIcon>))` 设置插槽的真实组件类型

