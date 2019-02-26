using System.Collections.Generic;

namespace Wem.Behaviour {

  public interface WemBehaviourInterface {

    /**
     * Adds an adjacent node.
     *
     * @param AdjacentConfig node
     *   The node to add as adjacent.
     * @param bool bidirectional
     *   Whether the edge is bidirectional or not.
     */
    void AddEdge(AdjacentConfig node, bool bidirectional = false);

    /**
     * Removes an adjacent node.
     *
     * @param WemBehaviour node
     *   The adjacent node to remove.
     */
    void RemoveEdge(WemBehaviour node);

    /**
     * Gets the WemBehaviour ID.
     *
     * @return string
     *   The WemBehaviour ID.
     */
    string GetId();

    /**
     * Gets all the adjacent nodes.
     *
     * @return List<AdjacentConfig>
     *   The adjacent nodes.
     */
    List<AdjacentConfig> GetAdjacents();

  }

}
