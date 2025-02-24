using UnityEngine;
using UnityEngine.Experimental.AI;

public class ActivateTrap : MonoBehaviour
{

  [SerializeField] private float sphereHeight = 1f;
  [SerializeField] private int totalSpheres = 10;
  [SerializeField] private float radius = 1f;
  [SerializeField] private float rotationSpeed = 50f;
  private bool noSpheres = true;
  private GameObject container;
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player") && noSpheres)
    {
      // create empty game object
      container = new GameObject("Trap Container");
      container.transform.position = other.transform.position;

      // populate the empty game object with spheres in a circular pattern around the player
      for (int i = 0; i < totalSpheres; i++)
      {
        float angle = i * (360f / totalSpheres);  // Calculate angle step
        float radian = angle * Mathf.Deg2Rad;  // Convert to radians

        Vector3 spawnPosition = other.transform.position + new Vector3(
            Mathf.Cos(radian) * radius,
            other.transform.position.y + sphereHeight,
            Mathf.Sin(radian) * radius
        );

        // Create the sphere
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.parent = container.transform;
        sphere.transform.position = spawnPosition;
        sphere.transform.localScale = new Vector3(.4f, .4f, .4f);

        // Assign tag and color to spheres
        string trapTag = (i == 5) ? "ReleaseSphere" : "TrapSphere";
        sphere.tag = trapTag;
        sphere.GetComponent<MeshRenderer>().material.color = (i == 5) ? Color.red : Color.white;

        // Add RigidBody
        Rigidbody rb = sphere.AddComponent<Rigidbody>();
        rb.isKinematic = true;
      }
      noSpheres = false;
    }
  }

  private void Update()
  {
    // apply rotation to the container
    if (container != null)
    {
      container.transform.RotateAround(container.transform.position, Vector3.up, 90 * Time.deltaTime);
    }
  }
}
