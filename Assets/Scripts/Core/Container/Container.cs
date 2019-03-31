using System.Collections.Generic;

namespace Wem.Container {

  public class Container : IContainer {

    protected static Dictionary<string, object> container = new Dictionary<string, object> ();

    public void Set(string id, object service) {
      Set2(id, service);
    }

    public object Get(string id) {
      return Get2(id);
    }

    public static void Set2(string id, object service) {
      if (!container.ContainsKey(id)) {
        container[id] = service;

        return;
      }

      container.Add(id, service);
    }

    public static object Get2(string id) {
      object service;
      if (!container.TryGetValue(id, out service)) {
        throw new ContainerException("The service " + id + " does not exist.");
      }

      return service;
    }

  }

}
