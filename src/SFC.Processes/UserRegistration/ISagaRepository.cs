﻿namespace SFC.Processes.UserRegistration
{
  public interface ISagaRepository
  {
    void Save(string id, object data);
    T Get<T>(string id) where T : class;
  }
}