using UnityEngine;

public class Ground : MonoBehaviour {

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      //Method1();
      //Method2();
      Method3();
    }
  }

  // ScreenToWorldPoint.
  void Method1() {
    Vector3 clickPosition = -Vector3.one;

    clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 90f));

    Debug.Log(clickPosition);
  }

  // Raycast using Colliders.
  void Method2() {
    Vector3 clickPosition = -Vector3.one;

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit)) {
      clickPosition = hit.point;
    }

    Debug.Log(clickPosition);
  }

  // Raycast using Plain.
  void Method3() {
    Vector3 clickPosition = -Vector3.one;

    Plane plane = new Plane(Vector3.up, 0f);
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    float distanceToPlane;

    if (plane.Raycast(ray, out distanceToPlane)) {
      clickPosition = ray.GetPoint(distanceToPlane);
    }

    Debug.Log(clickPosition);
  }
}
