﻿global using System.Text;
global using Ardalis.GuardClauses;
global using Ardalis.ListStartupServices;
global using Ardalis.Result.AspNetCore;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using Makc2024.Dummy.Gateway.DomainModel.App;
global using Makc2024.Dummy.Gateway.DomainModel.App.Config;
global using Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.QueryFilters;
global using Makc2024.Dummy.Gateway.Infrastructure.App;
global using Makc2024.Dummy.Gateway.UIs.WebUI.App.Middlewares;
global using Makc2024.Dummy.Shared.Query;
global using MediatR;
global using Microsoft.AspNetCore.Authentication;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.IdentityModel.Tokens;
