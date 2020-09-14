# 投票管理系统





## 业务介绍

* 一个投票表单只有一组投票
* 用户在登录后，才可以生成投票表单
* 投票项可以单选，可以多选
* 其他用户投票后显示当前投票结果（但是不能刷票）
* 投票有相应的时间，页面上需要出现倒计时
* 投票结果需要用不同的颜色不同长度的横条，并显示百分比人数

## 系统架构

此项目为单体应用，前端使用 [Bootstrap](https://getbootstrap.com/)，后端使用微软技术栈：

* [ASP.Net Core](https://docs.microsoft.com/zh-cn/aspnet/core)
* [Entity Framework Core](https://docs.microsoft.com/zh-cn/ef/)
* [SQL Server](https://docs.microsoft.com/zh-cn/sql/sql-server/)

VoteService作为一个简单的领域服务，来处理业务逻辑，以保持Controller的简洁

## 部署