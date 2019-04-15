using System.Collections.Generic;
using UnityEngine;
using Wem.Activity;

namespace Wem.Agenda {

  public class Agenda : IAgenda {

    public string Id {set;get;}
    public IActivity RootActivity {set; get;}

    /**
     * Base constructor.
     */
    public Agenda() {}

    /**
     * Constructor with Agenda's Id.
     */
    public Agenda(string id) {
      this.Id = id;
    }

    /**
     * {@inheritdoc}
     */
    public void AddEdge(IActivity a1, IActivity a2) {
      EdgeConfig config = new EdgeConfig(a2, 0.5);

      a1.AddEdge(config);
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      HashSet<string> printedNodes = new HashSet<string> ();

      return this.Id + ":\n" + ToStringHelper(this.RootActivity, printedNodes);
    }

    /**
     * Helper that converts agenda to string.
     *
     * @param Wem.Activity.IActivity root
     *   The root activity for the iteration.
     * @param HashSet<string> printedNodes
     *   Hash set of nodes that were already printed (to avoid infinite calls).
     * @param string indent
     *   The indentation for this iteration.
     */
    private string ToStringHelper(IActivity root, HashSet<string> printedNodes, string indent = "") {
      printedNodes.Add(root.GetId());

      string s = "";

      if (root.Equals(RootActivity)) {
        s += indent + root.GetId() + " -> \n";
      }

      indent += "  ";

      foreach (var edge in root.GetEdges()) {
        IActivity adj = edge.Adjacent;

        s += indent + adj.GetId();

        // Only prints the children of the adjacent node if they were not
        // previously printed.
        if (!printedNodes.Contains(adj.GetId())) {
          if(adj.GetEdges().Count > 0) {
            s += " -> ";
          }

          s += "\n";

          s += ToStringHelper(adj, printedNodes, indent);
        }
        else {
          s += "\n";
        }
      }

      return s;
    }

  }

}
