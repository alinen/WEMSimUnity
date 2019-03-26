using UnityEngine;

namespace Wem.Activity {

  public class Hover : Activity {

    public float rate = 1.0f;
    Vector3 startPosition = new Vector3(0, 0, 0);

    public Hover (string id, bool isRoot = false) : base(id, isRoot) {}

  }

}
