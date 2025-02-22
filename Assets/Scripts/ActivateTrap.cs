using UnityEngine;

public class ActivateTrap : MonoBehaviour
{

  private Rigidbody rb;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      Debug.Log("Player entered trap zone!");
    }
  }
}
