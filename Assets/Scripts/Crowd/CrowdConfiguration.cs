using System.Collections.Generic;

namespace Crowd {
  public class CrowdConfiguration {

    /**
     * Number of agents in the crowd.
     */
    public int NumAgents { get; private set; }

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
