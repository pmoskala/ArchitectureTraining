﻿using System;

namespace SFC.Processes.UserRegistration.Contract
{
  public class LoginNameAlreadyUsedException : Exception
  {
    public string LoginName { get; }

    public LoginNameAlreadyUsedException(string loginName)
    {
      LoginName = loginName;
    }
  }
}