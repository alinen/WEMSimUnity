using System;

namespace Wem.Activity {

  [Serializable()]
  public class InvalidActivityException : System.Exception {

    public InvalidActivityException() : base() {}

    public InvalidActivityException(string message) : base(message) {}

    public InvalidActivityException(string message, System.Exception inner)
      : base(message, inner) {}

  }

}
