using System.Collections.Generic;
using Wem.Activity;

namespace Wem.Agenda {

  public interface IAgenda {

    /**
     * The agenda's ID.
     */
    string Id {set;get;}

    /**
     * The root activity of the agenda graph.
     */
    IActivity RootActivity {set; get;}

    /**
     * Adds an edge between two activities.
     *
     * @param Wem.Activity.IActivity a1
     *   The source activity of the edge.
     * @param Wem.Activity.IActivity a2
     *   The destination activity of the edge.
     */
    void AddEdge(IActivity a1, IActivity a2);

    /**
     * Gets an activity from the agenda.
     *
     * @param string id
     *   The id of the activity to look up.
     *
     * @return Wem.Activity.IActivity
     *   The found activity.
     *
     * @throws Wem.Activity.InvalidActivityException
     *   If the activity could not be found.
     */
    IActivity GetActivity(string id);

  }

}
