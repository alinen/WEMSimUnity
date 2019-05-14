
namespace Wem.Container {

  public interface IContainer {

    /**
     * Sets a new service.
     *
     * @param string id
     *   The service id.
     * @param object service
     *   The new service.
     */
    void Set(string id, object service);

    /**
     * Gets service by id.
     *
     * @param string id
     *   The service id.
     */
    object Get(string id);

  }

}
