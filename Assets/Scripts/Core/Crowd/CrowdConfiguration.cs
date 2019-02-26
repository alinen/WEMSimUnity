using System;
using System.Collections.Generic;
using UnityEngine;

namespace Wem.Crowd {
  public class CrowdConfiguration : MonoBehaviour {

    /**
     * Number of agents in the crowd.
     */
    public int NumAgents;

    /**
     * List of agent distributions for the crowd.
     */
    public List<AgentDistribution> AgentDistributions;

    /**
     * Point 1 of the area in which the agents can be drawn.
     */
    public Vector2 Point1;

    /**
     * Point 2 of the area in which the agents can be drawn.
     */
    public Vector2 Point2;
  }

  [Serializable]
  public class AgentDistribution {
    public GameObject AgentTemplate;
    public float Distribution;
  }
}
