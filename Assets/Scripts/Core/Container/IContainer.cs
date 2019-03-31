
namespace Wem.Container {

  public interface IContainer {

    void Set(string id, object service);

    object Get(string id);

  }

}
