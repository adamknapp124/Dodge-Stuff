using UnityEngine;

public class DeactivateTraps : MonoBehaviour
{


  // Update is called once per frame
  void OnTriggerEnter(Collider other)
  {
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
