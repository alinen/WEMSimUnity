using System.Collections.Generic;
using UnityEngine;
using Wem.Behaviour;

namespace Wem.Activity {

  public class Activity : MonoBehaviour, ActivityInterface {

    public WemBehaviour RootBehaviour;
    bool update = true;
    HashSet<string> printedNodes = new HashSet<string> ();

    void Update() {
      if (update) {
        this.printActivity(this.RootBehaviour);

        update = false;
      }
    }

    protected void printActivity(WemBehaviourInterface root, string indent = "") {
      printedNodes.Add(root.GetId());

      if (root.Equals(RootBehaviour)) {
        Debug.Log(indent + root.GetId() + " -> ");
      }

      indent += "      ";

      foreach (var adj in root.GetAdjacents()) {
        Debug.Log(indent + adj.Adjacent.GetId() + " -> ");

        if (!printedNodes.Contains(adj.Adjacent.GetId())) {
          printActivity(adj.Adjacent, indent);
        }
      }
    }

  }

}
