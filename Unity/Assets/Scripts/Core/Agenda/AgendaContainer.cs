using System;
using System.Collections.Generic;
using Wem.Activity;
using Wem.Container;
using Wem.Yaml;

namespace Wem.Agenda {

  public class AgendaContainer {

    /**
     * The container of agendas.
     */
    Dictionary<string, IAgenda> container = new Dictionary<string, IAgenda> ();

    public static AgendaContainer create(IContainer container) {
      return new AgendaContainer();
    }

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
     */
    public IAgenda Get(string id) {
      IAgenda agenda;

      if (!container.TryGetValue(id, out agenda)) {
        throw new InvalidAgendaException("Agenda " + id + " was not found.");
      }

      return agenda;
    }

    /**
     * Gets an activity from the container by string id.
     *
     * @param Wem.Yaml.ActivityRef activiy
     *   The activity's reference.
     */
    public IActivity GetActivity(ActivityRef activity) {
      IAgenda agenda = this.Get(activity.Agenda);

      return agenda.GetActivity(activity.Activity);
    }

    /**
     * Gets an activity from the container by string id.
     *
     * @param string id
     *   The activity's ID in the form agenda::activity.
     */
    public IActivity GetActivity(string id) {

      string[] parts = id.Split(new[] { "::" }, StringSplitOptions.None);
      string agenda_name = parts[0];
      string activity_name = parts[1];

      // Gets the activity.
      IAgenda agenda = Get(agenda_name);
      IActivity activity = agenda.GetActivity(activity_name);

      return activity;
    }

  }

}
