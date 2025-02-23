using UnityEngine;

public class DeactivateTraps : MonoBehaviour
{

  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }
  private Rigidbody rb;
  // Update is called once per frame
  void OnTriggerEnter(Collider other)
  {
    // Get player position
    // Debug.Log("Position: " + other.transform.position);
    if (other.CompareTag("Player"))
    {
      GameObject[] traps = GameObject.FindGameObjectsWithTag("ToggleableTrigger");
      foreach (GameObject trap in traps)
      {
        Destroy(trap);
      }
    }
  }
}
