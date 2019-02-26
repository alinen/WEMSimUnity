using UnityEngine;

namespace Wem.Behaviour {

  public class Hover : WemBehaviour {

    public float rate = 1.0f;
    Vector3 startPosition;

    void Start() {
      this.id = "hover";
    }

  }

}
