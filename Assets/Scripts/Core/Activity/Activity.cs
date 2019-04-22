using System.Collections.Generic;
using System;
using Wem.Generic;

namespace Wem.Activity {

  public class Activity : IActivity {

    /**
     * The activity ID.
     */
    protected string id;

    /**
     * Whether the activity is root or not.
     */
    public bool IsRoot {protected set; get;}

    /**
     * The adjacent nodes.
     */
    protected List<EdgeConfig> edges = new List<EdgeConfig> ();

    /**
     * {@inheritdoc}
     */
    public Area Area {set; get;}

    /**
     * Wem.Activity.Activity constructor.
     */
    public Activity(string id, bool isRoot = false) {
      this.id = id;
      this.IsRoot = isRoot;
    }

    /**
     * {@inheritdoc}
     */
    public void AddEdge(EdgeConfig node) {
      edges.Add(node);
    }

    /**
     * {@inheritdoc}
     */
    public void RemoveEdge(IActivity node) {
      for (int i = 0; i < edges.Count; i++) {
        IActivity adjNode = edges[i].Adjacent;

        if (node.Equals(adjNode)) {
          edges.RemoveAt(i);
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
    public List<EdgeConfig> GetEdges() {
      return this.edges;
    }

  }

}
