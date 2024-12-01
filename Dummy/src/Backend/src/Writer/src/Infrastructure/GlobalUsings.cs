﻿global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Security.Claims;
global using System.Text;
global using Ardalis.GuardClauses;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using Ardalis.Specification.EntityFrameworkCore;
global using DotEnv.Core;
global using Makc2024.Dummy.Shared.Core.App;
global using Makc2024.Dummy.Shared.Core.Event;
global using Makc2024.Dummy.Writer.DomainModel.DummyItem;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Writer.Infrastructure.App.Config;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db;
global using Makc2024.Dummy.Writer.Infrastructure.App.Repository;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Serilog;
global using Serilog.Extensions.Logging;
