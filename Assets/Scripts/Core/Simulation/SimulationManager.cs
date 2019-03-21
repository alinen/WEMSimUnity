using System;
using System.Collections.Generic;
using UnityEngine;
using Wem.Group;

namespace Wem.Simulation {

  public class SimulationManager : MonoBehaviour {

    /**
     * List of group managers in the environment.
     */
    List<GroupManager> groupManagers = new List<GroupManager> ();

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
      GameObject[] crowds = GameObject.FindGameObjectsWithTag("GroupManager");
      foreach (GameObject crowd in crowds) {
        groupManagers.Add(crowd.GetComponent<GroupManager> ());
      }
    }

    /**
     * Creates and clones each agent.
     */
    private void createAgents() {
      foreach (GroupManager groupManager in this.groupManagers) {
        groupManager.Setup();
        groupManager.CreateAgents();
      }
    }

  }

}
