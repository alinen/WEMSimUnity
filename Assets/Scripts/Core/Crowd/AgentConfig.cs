using System;
using UnityEngine;

namespace Wem.Crowd {

  public class AgentConfig : ICloneable {

    /**
     * The agent's ID.
     */
    uint id {get; set;}

    /**
     * The agent's name.
     */
    string name {get; set;}

    /**
     * The agent's sex.
     */
    Sex sex = Sex.Other;

    /**
     * The agent's color (for debugging purposes).
     */
    Color color = Color.red;

    /**
     * Getter and setter for property sex.
     */
    public Sex Sex {
      get { return this.sex; }

      set {
        if (Enum.IsDefined(typeof(Sex), value)) {
          this.sex = value;
        }
      }
    }

    /**
     * Getter and setter for property color.
     */
    public Color Color {
      get { return this.color; }
      set { this.color = value; }
    }

    /**
     * @{inheritdoc}
     */
    public object Clone() {
      return this.MemberwiseClone();
    }
  }

  /**
   * Enum for the possible values of the property sex for an Agent.
   */
  public enum Sex : byte {
    Male,
    Female,
    Other,
  }
}
