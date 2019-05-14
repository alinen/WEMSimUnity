using System.Collections.Generic;
using UnityEngine;
using Wem.Activity;
using System;

namespace Wem.Agenda {

  public class Agenda : IAgenda {

    /**
     * A dictionary of activities for faster look ups.
     */
    Dictionary<string, IActivity> activities = new Dictionary<string, IActivity> ();

    /**
     * The agenda's root activity.
     */
    private IActivity rootActivity;

    /**
     * {@inheritdoc}
     */
    public string Id {set;get;}
    public IActivity RootActivity {
      get {
        return this.rootActivity;
      }
      set {
        this.AddToDictionary(value);

        this.rootActivity = value;
      }
    }

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

      // Adds the node to the dictionary.
      AddToDictionary(a2);
    }

    /**
     * {@inheritdoc}
     */
    public IActivity GetActivity(string id) {
      IActivity activity;
      if (!activities.TryGetValue(id, out activity)) {
        throw new InvalidActivityException("Activity " + id + " was not found.");
      }

      return activity;
    }

    /**
     * {@inheritdoc}
     */
    public override string ToString() {
      HashSet<string> printedNodes = new HashSet<string> ();

      return this.Id + ":\n" + ToStringHelper(this.RootActivity, printedNodes);
    }

    /**
     * Adds activity to dictionary.
     *
     * @param Wem.Activity.IActivity value
     *   The activity to add.
     */
    private void AddToDictionary(IActivity value) {
      IActivity activity;
      if (!activities.TryGetValue(value.Id, out activity)) {
        activities.Add(value.Id, value);
      }
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
      printedNodes.Add(root.Id);

      string s = "";

      if (root.Equals(RootActivity)) {
        s += indent + root.Id + " at " + root.Areas[0].Id + " -> \n";
      }

      indent += "  ";

      foreach (var edge in root.GetEdges()) {
        IActivity adj = edge.Adjacent;

        s +=  indent + adj.Id + " at " + adj.Areas[0].Id;

        // Only prints the children of the adjacent node if they were not
        // previously printed.
        if (!printedNodes.Contains(adj.Id)) {
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
