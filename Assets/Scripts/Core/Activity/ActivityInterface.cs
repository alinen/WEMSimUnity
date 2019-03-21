using System.Collections.Generic;

namespace Wem.Activity {

  public interface ActivityInterface {

    /**
     * Adds an adjacent node.
     *
     * @param EdgeConfig node
     *   The node to add as adjacent.
     * @param bool bidirectional
     *   Whether the edge is bidirectional or not.
     */
    void AddEdge(EdgeConfig node, bool bidirectional = false);

    /**
     * Removes an adjacent node.
     *
     * @param ActivityInterface node
     *   The adjacent node to remove.
     */
    void RemoveEdge(ActivityInterface node);

    /**
     * Gets the activity ID.
     *
     * @return string
     *   The Activity ID.
     */
    string GetId();

    /**
     * Gets all the adjacent nodes.
     *
     * @return List<EdgeConfig>
     *   The adjacent nodes.
     */
    List<EdgeConfig> GetAdjacents();

  }

}
