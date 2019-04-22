using System.Collections.Generic;
using Wem.Generic;

namespace Wem.Activity {

  public interface IActivity {

    /**
     * The area where the activity can take place.
     */
    Area Area {set; get;}

    /**
     * Adds an adjacent node.
     *
     * @param EdgeConfig node
     *   The node to add as adjacent.
     */
    void AddEdge(EdgeConfig node);

    /**
     * Removes an adjacent node.
     *
     * @param Wem.Activity.IActivity node
     *   The adjacent node to remove.
     */
    void RemoveEdge(IActivity node);

    /**
     * Gets the activity ID.
     *
     * @return string
     *   The activity ID.
     */
    string GetId();

    /**
     * Gets all the edges.
     *
     * @return List<EdgeConfig>
     *   The node's edges.
     */
    List<EdgeConfig> GetEdges();

  }

}
