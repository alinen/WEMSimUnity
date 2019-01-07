using System;
using System.Collections.Generic;
using UnityEngine;

namespace Crowd {

  public class CrowdSimulation : MonoBehaviour {

    /**
     * Number of agents in the crowd.
     */
    public int numAgents;

    /**
     * The GameObject template for the crowd.
     */
    public GameObject agentTemplate;

    /**
     * The configuration object for the crowd.
     */
    CrowdConfiguration config = new CrowdConfiguration();

    /**
     * The list of agents in the crowd.
     */
    List<Agent> agents = new List<Agent> ();

    /**
     * The Start() method.
     */
    public void Start() {
      config.numAgents = numAgents;

      Agent agent = createAgent();
      agents.Add(agent);

      System.Random random = new System.Random();

      for (int i = 0; i < config.numAgents - 1; i++) {
        Agent copy = (Agent) agent.Clone();

        float x = random.Next(-5, 5);
        float z = random.Next(-5, 5);

        copy.GameObject.transform.position += new Vector3(x, 0, z);

        agents.Add(copy);
      }
    }

    /**
     * Creates a single agent for the crowd.
     *
     * @return Agent
     *   The created agent.
     */
    private Agent createAgent() {
      AgentConfig config = new AgentConfig();
      config.Color = Color.blue;

      Agent agent  = new Agent(config, this.agentTemplate);

      return agent;
    }
  }

}
