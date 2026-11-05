using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private CharacterController controller;

    private void Awake() => controller = GetComponent<CharacterController>();

    private void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        controller.SimpleMove(transform.TransformDirection(input) * speed);
    }
}
