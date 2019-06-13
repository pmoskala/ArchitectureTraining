using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SFC.Processes.UserRegistration
{
  class SagaRepository : ISagaRepository
  {
    private static readonly Dictionary<string, string> _items = new Dictionary<string, string>();

    public void Save(string id, object data)
    {
      using (var sw = new StringWriter())
      {
        JsonSerializer.CreateDefault().Serialize(sw, data);
        string strData = sw.GetStringBuilder().ToString();

        _items[id] = strData;
      }
    }

    public T Get<T>(string id) where T:class
    {
      if (!_items.ContainsKey(id))
      {
        return null;
      }

      string data = _items[id];

      if (data == null)
      {
        return null;
      }

      using(var sr = new StringReader(data))
      using (var jr = new JsonTextReader(sr))
      {
        return JsonSerializer.CreateDefault().Deserialize<T>(jr);
      }
    }
  }
}