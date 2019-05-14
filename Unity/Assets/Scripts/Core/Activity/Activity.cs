using System.Collections.Generic;
using System;
using Wem.Generic;
using Wem.Map;

namespace Wem.Activity {

  public class Activity : IActivity {

    /**
     * The adjacent nodes.
     */
    protected List<EdgeConfig> edges = new List<EdgeConfig> ();

    /**
     * Whether the activity is root or not.
     */
    public bool IsRoot {protected set; get;}


    /**
     * {@inheritdoc}
     */
    public string Id {get; protected set;}

    /**
     * {@inheritdoc}
     */
    public List<Area> Areas {get; protected set;}

    /**
     * {@inheritdoc}
     */
    public Activity Link {get; set;}

    /**
     * Wem.Activity.Activity constructor.
     */
    public Activity(string id, bool isRoot = false) {
      this.Id = id;
      this.IsRoot = isRoot;

      this.Areas = new List<Area> ();
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
    public List<EdgeConfig> GetEdges() {
      return this.edges;
    }

  }

}
