﻿global using System.Reflection;
global using System.Runtime.CompilerServices;
global using Ardalis.GuardClauses;
global using Ardalis.SharedKernel;
global using Ardalis.Specification.EntityFrameworkCore;
global using DotEnv.Core;
global using Makc2024.Dummy.Writer.DomainModel.Customer;
global using Makc2024.Dummy.Writer.DomainModel.Invoice;
global using Makc2024.Dummy.Writer.DomainModel.Revenue;
global using Makc2024.Dummy.Writer.DomainModel.User;
global using Makc2024.Dummy.Writer.DomainUseCases.Customer;
global using Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetAll;
global using Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetCount;
global using Makc2024.Dummy.Writer.DomainUseCases.Customer.Actions.GetFiltered;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Create;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Delete;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetAmounts;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetById;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetCount;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFiltered;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetFilteredCount;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.GetLatest;
global using Makc2024.Dummy.Writer.DomainUseCases.Invoice.Actions.Update;
global using Makc2024.Dummy.Writer.DomainUseCases.Revenue.Actions.GetList;
global using Makc2024.Dummy.Writer.DomainUseCases.User;
global using Makc2024.Dummy.Writer.DomainUseCases.User.Actions.GetByEmail;
global using Makc2024.Dummy.Writer.Infrastructure.App.Config;
global using Makc2024.Dummy.Writer.Infrastructure.App.Db;
global using Makc2024.Dummy.Writer.Infrastructure.App.Repository;
global using Makc2024.Dummy.Writer.Infrastructure.Customer;
global using Makc2024.Dummy.Writer.Infrastructure.Customer.Actions.GetAll;
global using Makc2024.Dummy.Writer.Infrastructure.Customer.Actions.GetCount;
global using Makc2024.Dummy.Writer.Infrastructure.Customer.Actions.GetFiltered;
global using Makc2024.Dummy.Writer.Infrastructure.Customer.Entity;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.Create;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.Delete;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetAmounts;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetById;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetCount;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetFiltered;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetFilteredCount;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.GetLatest;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Actions.Update;
global using Makc2024.Dummy.Writer.Infrastructure.Invoice.Entity;
global using Makc2024.Dummy.Writer.Infrastructure.Revenue;
global using Makc2024.Dummy.Writer.Infrastructure.Revenue.Actions.GetList;
global using Makc2024.Dummy.Writer.Infrastructure.Revenue.Entity;
global using Makc2024.Dummy.Writer.Infrastructure.User;
global using Makc2024.Dummy.Writer.Infrastructure.User.Actions.GetByEmail;
global using Makc2024.Dummy.Writer.Infrastructure.User.Entity;
global using MediatR;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Serilog;
global using Serilog.Extensions.Logging;
global using Makc2024.Dummy.Shared.Event;
