using UnityEngine;

namespace Wem.Activity {

  public class Hover : Activity {

    public float rate = 1.0f;
    Vector3 startPosition;

    void Start() {
      this.id = "hover";
    }

  }

}
