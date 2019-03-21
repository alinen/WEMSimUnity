using UnityEngine;
using UnityEngine.AI;

public class GoTo : MonoBehaviour {

  public Vector3 dest;

  void Start() {
    NavMeshAgent agent = gameObject.GetComponent<NavMeshAgent> ();

    agent.SetDestination(this.dest);
  }
}
