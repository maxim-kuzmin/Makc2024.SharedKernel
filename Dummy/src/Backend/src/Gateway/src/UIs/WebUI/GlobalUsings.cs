﻿global using Ardalis.GuardClauses;
global using Ardalis.ListStartupServices;
global using Ardalis.Result;
global using FastEndpoints;
global using FastEndpoints.Swagger;
global using Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetAll;
global using Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetCount;
global using Makc2024.Dummy.Gateway.DomainUseCases.Customer.Actions.GetFiltered;
global using Makc2024.Dummy.Gateway.DomainUseCases.Customer.QueryFilters;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Create;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Delete;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetAmounts;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetById;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetCount;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetFiltered;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetFilteredCount;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.GetLatest;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.Actions.Update;
global using Makc2024.Dummy.Gateway.DomainUseCases.Invoice.QueryFilters;
global using Makc2024.Dummy.Gateway.DomainUseCases.Revenue.Actions.GetList;
global using Makc2024.Dummy.Gateway.DomainUseCases.User.Actions.GetByEmail;
global using Makc2024.Dummy.Gateway.Infrastructure.App;
global using Makc2024.Dummy.Gateway.UIs.WebUI.Customer.Endpoint;
global using Makc2024.Dummy.Gateway.UIs.WebUI.Invoice.Endpoint;
global using Makc2024.Dummy.Gateway.UIs.WebUI.Revenue.Endpoint;
global using Makc2024.Dummy.Gateway.UIs.WebUI.User.Endpoint;
global using MediatR;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Http;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Makc2024.Dummy.Shared.Query;
