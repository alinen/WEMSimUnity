using System.Collections.Generic;
using System;
using UnityEngine;

namespace Wem.Behaviour {

  public class WemBehaviour : MonoBehaviour, WemBehaviourInterface {

    /**
     * The behavior ID.
     */
    protected string id;

    /**
     * The adjacent nodes.
     */
    protected List<AdjacentConfig> adjacents = new List<AdjacentConfig> ();

    /**
     * {@inheritdoc}
     */
    public void AddEdge(AdjacentConfig node, bool bidirectional = false) {

      adjacents.Add(node);

      if (bidirectional) {
        AdjacentConfig config = new AdjacentConfig(this, 0.5);

        node.Adjacent.AddEdge(config);
      }
    }

    /**
     * {@inheritdoc}
     */
    public void RemoveEdge(WemBehaviour node) {
      for (int i = 0; i < adjacents.Count; i++) {
        WemBehaviourInterface adjNode = adjacents[i].Adjacent;

        if (node.Equals(adjNode)) {
          adjacents.RemoveAt(i);
        }
      }
    }

    /**
     * {@inheritdoc}
     */
    public string GetId() {
      return this.id;
    }

    /**
     * {@inheritdoc}
     */
    public List<AdjacentConfig> GetAdjacents() {
      return this.adjacents;
    }

  }

}
