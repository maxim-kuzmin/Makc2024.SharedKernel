﻿global using System.Text;
global using Ardalis.Result.AspNetCore;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using Makc2024.Dummy.Shared.Core.Query;
global using Makc2024.Dummy.Shared.Web.App.Middlewares;
global using Makc2024.Dummy.Writer.Apps.WebApp.App;
global using Makc2024.Dummy.Writer.DomainUseCases.App;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList.Query;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Writer.Infrastructure.App;
global using Makc2024.Dummy.Writer.Infrastructure.App.Config;
global using Makc2024.Dummy.Writer.Infrastructure.App.For.Grpc;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem.For.Grpc;
global using MediatR;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.IdentityModel.Logging;
global using Microsoft.IdentityModel.Tokens;
