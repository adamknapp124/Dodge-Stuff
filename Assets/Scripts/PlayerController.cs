using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float rotationSpeed = 200f;

  void Update()
  {
    // Movement input
    float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow
    float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down Arrow

    Vector3 move = new Vector3(0, 0, moveZ) * moveSpeed * Time.deltaTime;
    transform.Translate(move, Space.Self);

    // Rotation input
    if (moveX != 0)
    {
      transform.Rotate(Vector3.up * moveX * rotationSpeed * Time.deltaTime);
    }
  }
}
