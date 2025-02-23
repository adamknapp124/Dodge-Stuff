using UnityEngine;

public class RaycastTest : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 10, Color.green, .47f);
  }
}
