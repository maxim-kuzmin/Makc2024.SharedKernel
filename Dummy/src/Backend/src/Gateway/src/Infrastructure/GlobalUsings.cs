﻿global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Reflection;
global using Ardalis.GuardClauses;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using DotEnv.Core;
global using Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Gateway.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Gateway.Infrastructure.App;
global using Makc2024.Dummy.Gateway.Infrastructure.App.Config;
global using Makc2024.Dummy.Gateway.Infrastructure.DummyItem.Grpc;
global using Makc2024.Dummy.Shared.Core.App;
global using Makc2024.Dummy.Shared.Core.Event;
global using Makc2024.Dummy.Shared.Core.Http;
global using MediatR;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using Serilog;
global using Serilog.Extensions.Logging;
