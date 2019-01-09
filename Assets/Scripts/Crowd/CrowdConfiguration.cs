using System.Collections.Generic;
using UnityEngine;

namespace Crowd {
  public class CrowdConfiguration : MonoBehaviour {

    /**
     * Number of agents in the crowd.
     */
    public int NumAgents;

    /**
     * Point 1 of the area in which the agents can be drawn.
     */
    public Vector2 Point1;

    /**
     * Point 2 of the area in which the agents can be drawn.
     */
    public Vector2 Point2;

    /**
     * Constructor.
     *
     * @param int numAgents
     *   The number of agents in the crowd.
     */
    public CrowdConfiguration(int numAgents) {
      this.NumAgents = numAgents;
    }
  }
}
