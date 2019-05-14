using System.Collections.Generic;

namespace Wem.Container {

  public class Container : IContainer {

    /**
     * The service container.
     */
    protected static Dictionary<string, object> container = new Dictionary<string, object> ();

    /**
     * {@inheritdoc}
     */
    public void Set(string id, object service) {
      Set2(id, service);
    }

    /**
     * {@inheritdoc}
     */
    public object Get(string id) {
      return Get2(id);
    }

    /**
     * Sets a new service.
     *
     * @param string id
     *   The service id.
     * @param object service
     *   The new service.
     */
    public static void Set2(string id, object service) {
      if (!container.ContainsKey(id)) {
        container[id] = service;

        return;
      }

      container.Add(id, service);
    }

    /**
     * Gets service by id.
     *
     * @param string id
     *   The service id.
     */
    public static object Get2(string id) {
      object service;
      if (!container.TryGetValue(id, out service)) {
        throw new ContainerException("The service " + id + " does not exist.");
      }

      return service;
    }

  }

}
