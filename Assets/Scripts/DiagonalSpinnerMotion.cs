using UnityEngine;

public class DiagonalSpinnerMotion : MonoBehaviour
{
  public Rigidbody rb;
  Vector3 angleVelocity;

  void Start()
  {
    //Fetch the Rigidbody from the GameObject with this script attached
    rb = GetComponent<Rigidbody>();

    //Set the angular velocity of the Rigidbody (rotating around the X axis, 100 deg/sec)
    angleVelocity = new Vector3(0, 200, 0);
  }

  void FixedUpdate()
  {
    Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.fixedDeltaTime);
    rb.MoveRotation(rb.rotation * deltaRotation);
  }
}
