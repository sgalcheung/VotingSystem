# 投票管理系统

[![Build Status](https://dev.azure.com/sgalwork/VotingSystem/_apis/build/status/VotingSystem-Docker%20container-CI?branchName=master)](https://dev.azure.com/sgalwork/VotingSystem/_build/latest?definitionId=4&branchName=master)
[![Issues](https://img.shields.io/github/issues/sgalcheung/VotingSystem.svg)](https://github.com/sgalcheung/VotingSystem/issues)


## How to run
- firs, and import step is run `dotnet libman restore`, this is similar `npm install`

## 业务介绍

* 一个投票表单只有一组投票
* 用户在登录后，才可以生成投票表单
* 投票项可以单选，可以多选
* 其他用户投票后显示当前投票结果（但是不能刷票）
* 投票有相应的时间，页面上需要出现倒计时
* 投票结果需要用不同的颜色不同长度的横条，并显示百分比人数

## 系统架构

此项目为单体应用

前端使用 
* [Bootstrap](https://getbootstrap.com/)

后端使用微软技术栈：

* [ASP.Net Core](https://docs.microsoft.com/zh-cn/aspnet/core)
* [Entity Framework Core](https://docs.microsoft.com/zh-cn/ef/)
* [SQL Server](https://docs.microsoft.com/zh-cn/sql/sql-server/)

VoteService作为一个简单的领域服务，来处理业务逻辑，以保持Controller的简洁

## 部署

采用DevOps，使用 [Azure Pipelines](https://azure.microsoft.com/zh-cn/services/devops/pipelines/) 实现CI/CD自动化集成和持续交付(或部署)