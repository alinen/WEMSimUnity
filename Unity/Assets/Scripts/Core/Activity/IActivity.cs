using System.Collections.Generic;
using Wem.Generic;
using Wem.Map;

namespace Wem.Activity {

  public interface IActivity {

    /**
     * The ID of the activity.
     */
    string Id {get;}

    /**
     * The areas where the activity can take place.
     */
    List<Area> Areas {get;}

    /**
     * The next explicit actitivy.
     */
    Activity Link {get; set;}

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
     * Gets all the edges.
     *
     * @return List<EdgeConfig>
     *   The node's edges.
     */
    List<EdgeConfig> GetEdges();

  }

}
