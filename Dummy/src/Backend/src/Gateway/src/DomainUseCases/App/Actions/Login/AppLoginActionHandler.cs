﻿using Makc2024.Dummy.Gateway.DomainUseCases.App.Action.Command;

namespace Makc2024.Dummy.Gateway.DomainUseCases.App.Actions.Login;

public class AppLoginActionHandler(IAppActionCommandService _service) :
  ICommandHandler<AppLoginActionCommand, Result<AppLoginActionDTO>>
{
  public Task<Result<AppLoginActionDTO>> Handle(AppLoginActionCommand request, CancellationToken cancellationToken)
  {
    return _service.Login(request, cancellationToken);
  }
}
