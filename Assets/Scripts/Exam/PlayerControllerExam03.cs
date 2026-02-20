using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;
    public float nextFireTime = 0f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        nextFireTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered && !enableAutoFireMode)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (enableAutoFireMode)
            {
                enableAutoFireMode = false;
            }
            else
            {
                enableAutoFireMode = true;
            }
        }



        if (enableAutoFireMode && Time.time >= nextFireTime)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            nextFireTime = Time.time + autoFireInterval;
        }
    }
}
