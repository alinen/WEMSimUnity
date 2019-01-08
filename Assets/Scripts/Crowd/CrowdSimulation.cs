using System;
using System.Collections.Generic;
using UnityEngine;

namespace Crowd {

  public class CrowdSimulation : MonoBehaviour {

    // TODO: Use a Dictionary instead of two Lists.
    /**
     * Number of agents per crowd.
     */
    public List<int> numAgents;

    /**
     * GameObject template per crowd.
     */
    public List<GameObject> agentTemplates;

    /**
     * Configuration object per crowd.
     */
    List<CrowdConfiguration> configs = new List<CrowdConfiguration> ();

    /**
     * List of agents per crowd.
     */
    List<List<Agent>> agents = new List<List<Agent>> ();

    System.Random random = new System.Random();

    /**
     * The Start() method.
     */
    public void Start() {
      this.setConfigs();

      this.createAgents();
    }

    /**
     * Sets the crowd configurations.
     */
    private void setConfigs() {
      for (int i = 0; i < numAgents.Count; ++i) {
        CrowdConfiguration config = new CrowdConfiguration(numAgents[i]);

        configs.Add(config);
      }
    }

    /**
     * Creates and clones each agent.
     */
    private void createAgents() {
      for (int i = 0; i < agentTemplates.Count; ++i) {

        // Extend the list of crowds by one.
        agents.Add(new List<Agent> ());

        // Create a new agent and add it the recently created crowd.
        Agent agent = createAgent(agentTemplates[i]);
        agents[i].Add(agent);

        // Clones and add copies to the recently created crowd.
        cloneAgent(agent, configs[i].NumAgents - 1, i);
      }

    }

    /**
     * Creates a single agent for the crowd.
     *
     * @param UnityEngine.GameObject agentTemplate
     *   The game object template used by the created agent.
     *
     * @return Crowd.Agent
     *   The created agent.
     */
    private Agent createAgent(GameObject agentTemplate) {
      AgentConfig config = new AgentConfig();
      config.Color = Color.blue;

      Agent agent  = new Agent(config, agentTemplate);

      return agent;
    }

    /**
     * Clones an agent the number of times specified.
     *
     * @param Crowd.Agent agent
     *   The agent to be cloned.
     * @param int numOfCopies
     *   Number of copies for the given agent.
     * @param int agentIndex
     *   The index of the crowd in which the copies should be added.
     */
    private void cloneAgent(Agent agent, int numOfCopies, int agentIndex) {
      for (int i = 0; i < numOfCopies; ++i) {
        Agent copy = (Agent) agent.Clone();

        float x = random.Next(-15, 15);
        float z = random.Next(-15, 15);

        copy.GameObject.transform.position += new Vector3(x, 0, z);

        agents[agentIndex].Add(copy);
      }
    }
  }

}
