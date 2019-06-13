using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;

namespace SFC.Infrastructure
{
  public class AutofacSelfTest
  {
    public static void CheckRegistrations(IContainer container)
    {
      foreach (var componentRegistration in container.ComponentRegistry.Registrations)
      {
        foreach (var registrationService in componentRegistration.Services)
        {
          var registeredTargetType = registrationService.Description;
          var type = GetType(registeredTargetType);
          if (type == null)
          {
            throw new Exception($"Failed to parse type '{registeredTargetType}'");
          }

          var instance = container.Resolve(type);
          if (instance == null || !componentRegistration.Activator.LimitType.IsInstanceOfType(instance))
          {
            throw new Exception($"Failed create type '{type}'");
          }
        }
      }
    }

    private static Type GetType(string typeName)
    {
      var type = Type.GetType(typeName);
      if (type != null) return type;

      foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = assembly.GetType(typeName);
        if (type != null) return type;
      }
      return null;
    }
  }
}
