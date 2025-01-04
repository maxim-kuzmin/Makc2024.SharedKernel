﻿global using System.Text;
global using Ardalis.Result.AspNetCore;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using Makc2024.Dummy.Gateway.Apps.WebApp.App;
global using Makc2024.Dummy.Gateway.DomainUseCases.App;
global using Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Gateway.Infrastructure.App;
global using Makc2024.Dummy.Gateway.Infrastructure.App.Config;
global using Makc2024.Dummy.Gateway.Infrastructure.App.Config.Options;
global using Makc2024.Dummy.Shared.Core.Query;
global using Makc2024.Dummy.Shared.Web.App.Middlewares;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Logging;
global using Microsoft.IdentityModel.Tokens;
