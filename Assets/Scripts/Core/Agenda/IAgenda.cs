using Wem.Activity;

namespace Wem.Agenda {

  public interface IAgenda {

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

  }

}
