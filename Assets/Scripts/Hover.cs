using UnityEngine;

public class Hover : MonoBehaviour {

  public float rate = 1.0f;
  Vector3 startPosition;

  // Use this for initialization
  void Start()  {
    startPosition = transform.position;
  }

  // Update is called once per frame
  void Update()  {
    transform.position = startPosition + Mathf.Sin(Time.timeSinceLevelLoad * rate) * (new Vector3(0, 1, 0));
  }
}
