using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Wem.Activity
{

  public class GoTo : Activity {

    public Vector3 dest;

    public GoTo (string id, bool isRoot = false) : base(id, isRoot) {}

    /*void Start() {
      this.id = "goto";
      ActivityInterface behaviour = gameObject.GetComponent<Hover> ();
      AdjacentConfig config = new AdjacentConfig(behaviour, 0.5);
      AddEdge(config, true);

      config = new AdjacentConfig(this, 0.5);
      AddEdge(config);

      //RemoveEdge(this);

      NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent> ();
      agent.SetDestination(this.dest);
    }*/

  }

}

