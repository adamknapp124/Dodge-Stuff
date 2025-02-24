using System;
using System.Collections;
using Cinemachine.Utility;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : MonoBehaviour
{
  private Vector3 PlayerMovementInput;
  private Vector2 PlayerMouseInput;

  private float xRot;
  private bool dashing = false;
  private float dashingTime = 0.1f;
  private float dashingCooldown = 1f;
  public Vector3 velocity;
  private bool isTrapped = false;


  [SerializeField] private LayerMask FloorMask;
  [SerializeField] private Transform FeetTransform;
  [SerializeField] private Transform PlayerCamera;
  [SerializeField] private Rigidbody PlayerBody;
  [SerializeField] private Animator animator;
  [SerializeField] private float Speed = 5f;
  [SerializeField] private float Sensitivity = 2f;


  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    // Get player input for movement
    PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
    // Get mouse input for camera movement
    PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

    if (Input.GetKey(KeyCode.LeftShift) && !dashing)
    {
      StartCoroutine(Dash());
    }

    MovePlayer();
    MovePlayerCamera();
    OnFire();
  }

  private void MovePlayer()
  {
    // forward and backward animations
    if (PlayerMovementInput != Vector3.zero && !isTrapped)
    {
      if (Input.GetKey(KeyCode.W))
      {
        animator.SetBool("isWalking", true);
      }
      if (Input.GetKey(KeyCode.S))
      {
        animator.SetBool("isWalkingBackward", true);
      }
      else
      {
        animator.SetBool("isWalkingBackward", false);
      }

      float currentSpeed = PlayerMovementInput.magnitude * Speed;
      animator.SetFloat("Speed", currentSpeed);
    }
    else
    {
      animator.SetBool("isWalking", false);
      animator.SetFloat("Speed", 0f);
    }

    if (isTrapped)
    {
      return;
    }
    Vector3 moveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
    PlayerBody.linearVelocity = new Vector3(moveVector.x, 0f, moveVector.z);
  }

  private void MovePlayerCamera()
  {
    if (Input.GetMouseButton(1))
    {
      xRot -= PlayerMouseInput.y * Sensitivity;
      xRot = Mathf.Clamp(xRot, -75f, 60f);
      transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);  // Rotate player horizontally
      PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);  // Rotate camera vertically
    }
  }


  public void OnFire()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Debug.Log("Firing weapon");
    }
  }

  private IEnumerator Dash()
  {
    dashing = true;
    Speed = 40f;
    yield return new WaitForSeconds(dashingTime);
    Speed = 5f;
    yield return new WaitForSeconds(dashingCooldown);
    dashing = false;
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("NormalTrigger"))
    {
      isTrapped = true;
      animator.SetBool("isWalking", false);
    }
  }
}
