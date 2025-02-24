using UnityEngine;

public class RaycastTest : MonoBehaviour
{
  [SerializeField] private float maxDistance = 10f;

  void FixedUpdate()
  {
    Ray ray = new(transform.position, transform.forward);

    Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.blue); // Visualize the ray

    if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
    {
      if (hit.collider.CompareTag("TrapSphere"))
      {
        Debug.Log("Hit the TrapSphere");
        Debug.DrawLine(ray.origin, hit.point, Color.red);
      }
    }
    else
    {
      Debug.Log("No hit detected.");
    }
  }
}
