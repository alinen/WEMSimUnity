using System.Collections.Generic;
using Wem.Agenda;

namespace Wem.Agenda {

  public class AgendaContainer {

    /**
     * The container of agendas.
     */
    Dictionary<string, IAgenda> container = new Dictionary<string, IAgenda> ();

    /**
     * Adds an agenda to the container.
     *
     * @param string id
     *   The agenda's ID.
     * @param Wem.Agenda.IAgenda agenda
     *   The agenda to be added.
     */
    public void Add(string id, IAgenda agenda) {
      if (!container.ContainsKey(id)) {
        container.Add(id, agenda);
      }
    }

    /**
     * Gets an agenda from the container.
     *
     * @param string id
     *   The agenda's ID.
     *
     * @return Wem.Agenda.IAgenda
     *   The agenda to retrieve.
     */
    public IAgenda Get(string id) {
      IAgenda agenda;

      if (!container.TryGetValue(id, out agenda)) {
        throw new InvalidAgendaException("Agenda " + id + " was not found.");
      }

      return agenda;
    }

  }

}