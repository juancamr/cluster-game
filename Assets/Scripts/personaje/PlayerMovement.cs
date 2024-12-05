using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement; // Importar para manejar escenas

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    public float jumpForce = 7f; // Fuerza de salto
    public float mouseSensitivity = 100f; // Sensibilidad del ratón

    public Transform cameraTransform; // Referencia a la cámara del jugador

    private Rigidbody rb; // Referencia al Rigidbody
    private float verticalRotation = 0f; // Rotación vertical de la cámara
    private bool isGrounded; // Indica si el jugador está en el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Bloquear el cursor en el centro de la pantalla
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Control de rotación con el ratón
        HandleMouseLook();

        // Movimiento del jugador con WASD
        HandleMovement();

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }

    private void HandleMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveHorizontal + transform.forward * moveVertical;
        Vector3 velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        rb.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Detectar si el jugador está en el suelo o en un camión
        if (collision.gameObject.CompareTag("Truck") || collision.gameObject.CompareTag("Obstaculo"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            RestartScene(); // Reiniciar la escena al tocar el suelo
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Truck") || collision.gameObject.CompareTag("Obstaculo"))
        {
            isGrounded = false;
        }
    }

    private void RestartScene()
    {
        // Reiniciar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
