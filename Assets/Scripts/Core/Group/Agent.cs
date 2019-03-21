using System;
using UnityEngine;
using UnityEngine.AI;

namespace Wem.Group {

  public class Agent : ICloneable {

    /**
     * The configuration object for the agent.
     */
    AgentConfig config;

    /**
     * The GameObject for the agent.
     */
    GameObject gameObject;

    /**
     * Constructor.
     *
     * @param Group.AgentConfig config.
     *   The agent configuration object for the agent.
     * @param UnityEngine.GameObject template.
     *   The game objec for the agent.
     */
    public Agent(AgentConfig config, GameObject gameObject) {
      this.config = config;
      this.gameObject = gameObject;
    }

    /**
     * Default constructor.
     */
    public Agent() {}

    /**
     * Getter for property gameObject.
     */
    public GameObject GameObject {
      get { return this.gameObject; }
    }

    /**
     * @{inheritdoc}
     */
    public object Clone() {
      Agent clone = new Agent();

      clone.gameObject = GameObject.Instantiate(this.gameObject);
      clone.config = (AgentConfig) config.Clone();

      return clone;
    }

  }

}
