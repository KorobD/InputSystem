using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    [SerializeField, Range (0, 10)] private float speedMove = 5f;
    [SerializeField, Range (0, 5)] private float jumpForce = 5f;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField, Range (0.1f, 1f)] private float rayDistance = 0.45f;


    private bool playerIsGround = true;

    public float SpeedMove { get { return speedMove; } }
    public float JumpForce { get { return jumpForce; } }
    public bool PlayerIsGround { get { return playerIsGround; } }


    private void Awake() {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update() {
        GroundCheck();
        
    }

    private void GroundCheck() {
        RaycastHit2D checkGround = Physics2D.Raycast(rigidbody2D.position, Vector2.down, rayDistance, groundLayer);
        if (checkGround.collider != null) {
            playerIsGround = true;
        } else {
            playerIsGround = false;
        }
    }
}
