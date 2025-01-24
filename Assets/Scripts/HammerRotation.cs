using UnityEngine;

public class HammerRotation : MonoBehaviour
{
  public float moveSpeed = 150f;
  public Vector3 rotationAxis = Vector3.right;

  void Update()
  {
    transform.Rotate(rotationAxis * moveSpeed * Time.deltaTime);
  }
}