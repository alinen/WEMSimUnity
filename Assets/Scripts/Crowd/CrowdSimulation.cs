using System;
using System.Collections.Generic;
using UnityEngine;

namespace Crowd {

  public class CrowdSimulation : MonoBehaviour {

    /**
     * Defines a Crowd class a List of Agents.
     */
    class Crowd : List<Agent> {}

    /**
     * GameObject template per crowd.
     */
    public List<GameObject> agentTemplates;

    /**
     * Configuration object per crowd.
     */
    List<CrowdConfiguration> configs = new List<CrowdConfiguration> ();

    /**
     * List of crowds.
     */
    List<Crowd> crowds = new List<Crowd> ();

    /**
     * Used to generate random numbers.
     */
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
      for (int i = 0; i < agentTemplates.Count; ++i) {
        // Gets the crowd configuration assigned to the agent template.
        CrowdConfiguration config = agentTemplates[i].GetComponent<CrowdConfiguration> ();

        configs.Add(config);
      }
    }

    /**
     * Creates and clones each agent.
     */
    private void createAgents() {
      for (int i = 0; i < agentTemplates.Count; ++i) {

        // Extend the list of crowds by one.
        crowds.Add(new Crowd());

        // Create a new agent and add it the recently created crowd.
        Agent agent = createAgent(agentTemplates[i]);
        crowds[i].Add(agent);

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
     * @param int crowdIndex
     *   The index of the crowd in which the copies should be added.
     */
    private void cloneAgent(Agent agent, int numOfCopies, int crowdIndex) {
      for (int i = 0; i < numOfCopies; ++i) {
        Agent copy = (Agent) agent.Clone();

        CrowdConfiguration config = configs[crowdIndex];

        float x = getRandomPosition(config.Point1.x, config.Point2.x);
        float z = getRandomPosition(config.Point1.y, config.Point2.y);

        copy.GameObject.transform.position = new Vector3(x, 0, z);

        crowds[crowdIndex].Add(copy);
      }
    }

    /**
     * Generates a random number between two values.
     *
     * @param float value1
     *   The first value for the range.
     * @param float value1
     *   The second value for the range.
     *
     * @return int
     *   The random value in-between the given ones.
     */
    private int getRandomPosition(float value1, float value2) {
      int min = (int) value1;
      int max = (int) value2;

      // If the min is greater than the max, swap the values.
      if (min > max) {
        int temp = min;
        min = max;
        max = temp;
      }

      return random.Next(min, max);
    }
  }

}
