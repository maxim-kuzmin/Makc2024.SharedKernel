using Makc2024.Dummy.Reader.Apps.InboxConsumerApp;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
