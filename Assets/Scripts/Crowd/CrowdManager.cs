using System.Collections.Generic;
using UnityEngine;

namespace Crowd {
  public class CrowdManager : MonoBehaviour {

    public CrowdConfiguration config;

    List<Agent> agents = new List<Agent> ();

    Dictionary<int, Agent> distributionMap = new Dictionary<int, Agent> ();

    /**
     * Used to generate random numbers.
     */
    System.Random random = new System.Random();

    /**
     * The Start() method.
     */
    private void Start() {
      this.setupDistributionMap();

      // Reset the position of the initial agents.
      // TODO: will be removed with a more complex positioning of characters.
      for (int i = 0; i < config.AgentDistributions.Count; ++i) {
        AgentDistribution dist = config.AgentDistributions[i];

        float x = getRandomPosition(config.Point1.x, config.Point2.x);
        float z = getRandomPosition(config.Point1.y, config.Point2.y);

        dist.AgentTemplate.transform.position = new Vector3(x, 0, z);
      }
    }

    /**
     * Creates agents based on distribution.
     */
    public void CreateAgents() {
      // Clones the agent templates.
      for (int i = 0; i < config.NumAgents - config.AgentDistributions.Count; ++i) {
        Agent agent = getRamdonAgent();

        // Clones and add a copy to the crowd.
        Agent copy = cloneAgent(agent);
        agents.Add(copy);
      }
    }

    /**
     * Sets up the distribution map for density and agent template.
     *
     * Example:
     * 20 : Template1 -> density of .20
     * 65 : Template2 -> density of .45
     * 100: Template3 -> density of .35
     */
    private void setupDistributionMap() {
      int accumulator = 0;

      for (int i = 0; i < config.AgentDistributions.Count; ++i) {
        AgentDistribution dist = config.AgentDistributions[i];

        accumulator += (int) (dist.Distribution * 100.0);
        Agent agent = createAgent(dist.AgentTemplate);

        distributionMap.Add(accumulator, agent);
      }
    }

    /**
     * Gets a random agent template based on the distribution.
     *
     * @return Agent
     *   The random agent template.
     */
    private Agent getRamdonAgent() {
      int n = random.Next(1, 100);

      foreach (KeyValuePair<int, Agent> entry in distributionMap) {

        // If the random number 'falls' in the entry's area.
        if (n <= entry.Key) {
          return entry.Value;
        }
      }

      return null;
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

      Agent agent  = new Agent(config, agentTemplate);

      return agent;
    }

    /**
     * Clones an agent.
     *
     * @param Crowd.Agent agent
     *   The agent to be cloned.
     */
    private Agent cloneAgent(Agent agent) {
      Agent copy = (Agent) agent.Clone();

      float x = getRandomPosition(config.Point1.x, config.Point2.x);
      float z = getRandomPosition(config.Point1.y, config.Point2.y);

      copy.GameObject.transform.position = new Vector3(x, 0, z);

      return copy;
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
