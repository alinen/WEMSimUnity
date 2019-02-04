using Crowd;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Simulation {

  public class SimulationManager : MonoBehaviour {

    /**
     * List of crowd managers in the environment.
     */
    List<CrowdManager> crowdManagers = new List<CrowdManager> ();

    /**
     * The Start() method.
     */
    private void Start() {
      this.initCrowdManagers();
      this.createAgents();
    }

    /**
     * Populates the crowdManagers property.
     */
    private void initCrowdManagers() {
      GameObject[] crowds = GameObject.FindGameObjectsWithTag("CrowdManager");
      foreach (GameObject crowd in crowds) {
        crowdManagers.Add(crowd.GetComponent<CrowdManager> ());
      }
    }

    /**
     * Creates and clones each agent.
     */
    private void createAgents() {
      foreach (CrowdManager crowdManager in this.crowdManagers) {
        crowdManager.Setup();
        crowdManager.CreateAgents();
      }
    }

  }

}
