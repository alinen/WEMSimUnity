using System.Collections.Generic;
using System;
using UnityEngine;

namespace Wem.Activity {

  public class Activity : ActivityInterface {

    /**
     * The behavior ID.
     */
    protected string id;

    /**
     * The adjacent nodes.
     */
    protected List<EdgeConfig> adjacents = new List<EdgeConfig> ();

    /**
     * {@inheritdoc}
     */
    public void AddEdge(EdgeConfig node, bool bidirectional = false) {

      adjacents.Add(node);

      if (bidirectional) {
        EdgeConfig config = new EdgeConfig(this, 0.5);

        node.Adjacent.AddEdge(config);
      }
    }

    /**
     * {@inheritdoc}
     */
    public void RemoveEdge(ActivityInterface node) {
      for (int i = 0; i < adjacents.Count; i++) {
        ActivityInterface adjNode = adjacents[i].Adjacent;

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
    public List<EdgeConfig> GetAdjacents() {
      return this.adjacents;
    }

  }

}
