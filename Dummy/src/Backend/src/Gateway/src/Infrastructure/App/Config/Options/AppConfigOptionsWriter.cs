namespace Makc2024.Dummy.Gateway.Infrastructure.App.Config.Options;

public record AppConfigOptionsWriter(string GrpcApiAddress, string RestApiAddress, AppTransport Transport);
