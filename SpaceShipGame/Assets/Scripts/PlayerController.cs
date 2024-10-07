using UnityEngine;

// Controls player movement and rotation.
public class PlayerController : MonoBehaviour
{
    public float speed = 1f; // Set player's movement speed.
    public float rotationSpeed = 1f; // Set player's rotation speed.

    public BulletManager bulletManager;

    private Rigidbody _rb; // Reference to player's Rigidbody.

    // Start is called before the first frame update
    private void Start()
    {
        _rb = GetComponent<Rigidbody>(); // Access player's Rigidbody.
        bulletManager.shipSpeed = speed;
      //  bulletManager = (BulletManager)ScriptableObject.CreateInstance<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            bulletManager.shootBullet(transform, speed);
        }
        // Move player based on vertical input.
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * moveVertical * speed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        _rb.MoveRotation(_rb.rotation * turnRotation);
    }
}