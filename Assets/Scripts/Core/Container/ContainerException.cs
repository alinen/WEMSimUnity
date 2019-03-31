using System;

namespace Wem.Container {

  [Serializable()]
  public class ContainerException : System.Exception {

    public ContainerException() : base() {}

    public ContainerException(string message) : base(message) {}

    public ContainerException(string message, System.Exception inner)
      : base(message, inner) {}

  }

}
