using UnityEngine;

public class RaycastTest : MonoBehaviour
{
  [SerializeField] private float maxDistance = 10f;
  [SerializeField] private PlayerController playerController;

  void FixedUpdate()
  {
    Ray ray = new(transform.position, transform.forward);

    if (Physics.Raycast(ray, out RaycastHit hit, maxDistance))
    {
      if (hit.collider.CompareTag("ReleaseSphere"))
      {
        if (playerController != null)
        {
          Debug.Log("Trap released!");
        }
      }
    }
  }
}
