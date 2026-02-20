using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;


    // Exam 05 ...
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;

    public float nextReload;
    public float remainBullet;
    // ...

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    private void Start()
    {
        nextReload = Time.time;
        remainBullet = maxBulletCount;
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

        if (shootAction.triggered && Time.time >= nextReload)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            remainBullet--;
            Debug.Log($"Bullet: {remainBullet}");
        }

        if (remainBullet == 0)
        {
            Debug.Log("Reload");
            nextReload = Time.time + bulletRegenerateCooldown;
            remainBullet = maxBulletCount;
        }
    }
}
