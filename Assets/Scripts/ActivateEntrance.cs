using UnityEngine;

public class ActivateEntrance : MonoBehaviour
{

  private GameObject objectToDestroy;
  void Start()
  {
    objectToDestroy = GameObject.FindWithTag("DestroyedEntranceTrap");

    if (objectToDestroy == null)
    {
      Debug.LogError("objectToDestroy not found! Make sure the tag is correct.");
    }
  }
  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      Destroy(objectToDestroy);
    }
  }
}
