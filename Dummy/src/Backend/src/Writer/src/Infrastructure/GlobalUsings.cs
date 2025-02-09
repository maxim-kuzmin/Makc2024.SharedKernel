﻿global using System.IdentityModel.Tokens.Jwt;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using Ardalis.GuardClauses;
global using Ardalis.Result;
global using Ardalis.SharedKernel;
global using Ardalis.Specification.EntityFrameworkCore;
global using Google.Protobuf.WellKnownTypes;
global using Grpc.Core;
global using Makc2024.Dummy.Shared.Core.App;
global using Makc2024.Dummy.Shared.DomainUseCases.Db.Helpers;
global using Makc2024.Dummy.Shared.DomainUseCases.Query;
global using Makc2024.Dummy.Shared.Infrastructure.Db;
global using Makc2024.Dummy.Shared.Infrastructure.Grpc;
global using Makc2024.Dummy.Writer.DomainModel.AppEvent;
global using Makc2024.Dummy.Writer.DomainModel.AppEventPayload;
global using Makc2024.Dummy.Writer.DomainModel.DummyItem;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Action.Command;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Actions.Login;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Db;
global using Makc2024.Dummy.Writer.DomainUseCases.App.Db.Helpers;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Command;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Query;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Action.Query.Service;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Get;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.Actions.Update;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEvent.DTOs;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Command;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Action.Query.Service;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Get;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.Actions.Update;
global using Makc2024.Dummy.Writer.DomainUseCases.AppEventPayload.DTOs;
global using Makc2024.Dummy.Writer.DomainUseCases.AppOutbox.Action.Command;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Action.Command;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Action.Query;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Action.Query.Service;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Get;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.Actions.Update;
global using Makc2024.Dummy.Writer.DomainUseCases.DummyItem.DTOs;
global using Makc2024.Dummy.Writer.Infrastructure.App.Action.Command;
global using Makc2024.Dummy.Writer.Infrastructure.App.Config;
global using Makc2024.Dummy.Writer.Infrastructure.App.Config.Options;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Settings;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db.For.PostgreSQL.Settings.Entities;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db.Settings;
global using Makc2024.Dummy.Writer.Infrastructure.App.Domain;
global using Makc2024.Dummy.Writer.Infrastructure.App.Repository;
global using Makc2024.Dummy.Writer.Infrastructure.AppEvent;
global using Makc2024.Dummy.Writer.Infrastructure.AppEvent.Action.Query;
global using Makc2024.Dummy.Writer.Infrastructure.AppEvent.Entity;
global using Makc2024.Dummy.Writer.Infrastructure.AppEventPayload;
global using Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Action.Query;
global using Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.Entity;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem.Action.Query;
global using Makc2024.Dummy.Writer.Infrastructure.DummyItem.Entity;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Serilog;
global using Serilog.Extensions.Logging;
global using AppEventPayloadServiceBaseForGrpc = Makc2024.Dummy.Writer.Infrastructure.AppEventPayload.For.Grpc.AppEventPayload.AppEventPayloadBase;
global using AppEventServiceBaseForGrpc = Makc2024.Dummy.Writer.Infrastructure.AppEvent.For.Grpc.AppEvent.AppEventBase;
global using AppServiceBaseForGrpc = Makc2024.Dummy.Writer.Infrastructure.App.For.Grpc.App.AppBase;
global using DummyItemServiceBaseForGrpc = Makc2024.Dummy.Writer.Infrastructure.DummyItem.For.Grpc.DummyItem.DummyItemBase;
