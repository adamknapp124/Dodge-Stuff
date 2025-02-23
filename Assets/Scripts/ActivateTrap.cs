using UnityEngine;
using UnityEngine.Experimental.AI;

public class ActivateTrap : MonoBehaviour
{

  [SerializeField] private float sphereHeight = 1f;
  [SerializeField] private int totalSpheres = 10;
  [SerializeField] private float radius = 1f;
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      // Generate spheres in a circular pattern around the player
      for (int i = 0; i < totalSpheres; i++)
      {
        float angle = i * (360f / totalSpheres);  // Calculate angle step
        float radian = angle * Mathf.Deg2Rad;  // Convert to radians

        Debug.Log(sphereHeight + other.transform.position.y);

        Vector3 spawnPosition = other.transform.position + new Vector3(
            Mathf.Cos(radian) * radius,
            other.transform.position.y + sphereHeight,
            Mathf.Sin(radian) * radius
        );

        // Create the sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = spawnPosition;
        sphere.transform.localScale = new Vector3(.5f, .5f, .5f);
        Rigidbody rb = sphere.AddComponent<Rigidbody>();
        rb.isKinematic = true;
      }
    }
  }
}
