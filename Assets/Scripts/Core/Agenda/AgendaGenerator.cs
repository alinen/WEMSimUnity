using System;
using System.Collections.Generic;
using Wem.Activity;

namespace Wem.Agenda {

  public class AgendaGenerator {

    Dictionary<string, IActivity> activities = new Dictionary<string, IActivity> ();

    IAgenda agenda = new Agenda();

    /**
     * Gets the generated agenda.
     *
     * @return Wem.Agenda.IAgenda
     *   The generated agenda.
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
     * @return Wem.Activity.IActivity
     *   The newly created activity instance.
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
          activityClass + " does not implement Wem.Activity.IInterface");
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
      IActivity a1 = GetActivity(k1);
      IActivity a2 = GetActivity(k2);

      this.agenda.AddEdge(a1, a2);
    }

    /**
     * Gets an activity from dictionary.
     *
     * @param string key
     *   The activity key.
     *
     * @return IActivity
     *   The associated activity.
     *
     * @throws Wem.Activity.InvalidActivityException
     *   If key does not map to an activity.
     */
    protected IActivity GetActivity(string key) {
      IActivity activity;

      if (!activities.TryGetValue(key, out activity)) {
        throw new InvalidActivityException(
          key + " does not have an associated activity");
      }

      return activity;
    }

  }

}
