using System;

namespace Wem.Agenda {

  [Serializable()]
  public class InvalidAgendaException : System.Exception {

    public InvalidAgendaException() : base() {}

    public InvalidAgendaException(string message) : base(message) {}

    public InvalidAgendaException(string message, System.Exception inner)
      : base(message, inner) {}

  }

}
