using Makc2024.Dummy.Writer.Apps.OutboxProducerApp;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
