using System;
using System.Collections.Generic;
using Wem.Activity;
using Wem.Container;

namespace Wem.Agenda {

  public class AgendaGenerator {

    Dictionary<string, IActivity> activities = new Dictionary<string, IActivity> ();

    IAgenda agenda = new Agenda();

    public static AgendaGenerator create(IContainer container) {
      return new AgendaGenerator();
    }

    /**
     * Gets the generated agenda.
     */
    public IAgenda GetAgenda() {
      return this.agenda;
    }

    /**
     * Creates a new activity of the type passed in activityClass.
     *
     * @param string key
     *   The key to store this activity in the dictionary.
     * @param string activityClass
     *   The class to instantiate as an activity.
     * @param string id
     *   The id of the activity (passed to the class instance).
     * @param bool isRoot
     *   Whether this activity is root or not.
     *
     * @throws Wem.Activity.InvalidActivityException
     *   If the activity class does not exist.
     */
    public IActivity NewActivity(string key, string activityClass, string id, bool isRoot = false) {
      Type activityType = Type.GetType(activityClass);

      if (activityType == null) {
        throw new InvalidActivityException(
          activityClass + " was not found");
      }

      /* Creates an istance of the activity class */
      IActivity activity = Activator.CreateInstance(activityType, id, isRoot) as IActivity;
      if (activity == null) {
        throw new InvalidActivityException(
          activityClass + " does not implement Wem.Activity.IActivity");
      }

      if (isRoot) {
        this.agenda.RootActivity = activity;
      }

      this.activities.Add(key, activity);

      return (IActivity) activity;
    }

    /**
     * Adds an edge between two activities.
     *
     * @param string k1
     *   The key in dictionary of source activity.
     * @param Wem.Activity.IActivity k2
     *   The key in dictionary of destination activity.
     */
    public void AddEdge(string k1, string k2) {
      IActivity a1 = this.getActivity(k1);
      IActivity a2 = this.getActivity(k2);

      this.agenda.AddEdge(a1, a2);
    }

    /**
     * Resets the generator, so a new Agenda can be created.
     */
    public void Start(string id) {
      this.activities = new Dictionary<string, IActivity> ();

      this.agenda = new Agenda(id);
    }

    /**
     * Gets an activity from dictionary.
     *
     * @param string key
     *   The activity key.
     *
     * @throws Wem.Activity.InvalidActivityException
     *   If key does not map to an activity.
     */
    protected IActivity getActivity(string key) {
      IActivity activity;

      if (!activities.TryGetValue(key, out activity)) {
        throw new InvalidActivityException(
          key + " does not have an associated activity");
      }

      return activity;
    }

  }

}
