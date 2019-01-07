using System;
using UnityEngine;

namespace Crowd {

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
     * @param Crowd.AgentConfig config.
     *   The agent configuration object for the agent.
     * @param UnityEngine.GameObject template.
     *   The game objec for the agent.
     */
    public Agent(AgentConfig config, GameObject gameObject) {
      this.config = config;
      this.gameObject = gameObject;

      this.applyConfigToObject();
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
     * Applies the properties set in the configuration object.
     */
    public void applyConfigToObject() {
      this.applyMaterial();
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

    /**
     * Applies the material set in the configuration object.
     */
    private void applyMaterial() {
      Renderer rend = gameObject.GetComponent<Renderer> ();

      rend.material.color = config.Color;
    }

  }

}
