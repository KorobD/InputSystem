using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float speedMove;
    private float jumpForce;
    private bool playerIsGround;

    [SerializeField] private GameInput gameInput;
    private Player player;
    private Rigidbody2D rigidbody2D;
    public event EventHandler OnPressUse;


    private void Awake() {
        player = GetComponent<Player>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        speedMove = player.SpeedMove;
        jumpForce = player.JumpForce;
        playerIsGround = player.PlayerIsGround;

    }

    private void Start() {
        gameInput.OnJumpAction += Jump;
        gameInput.OnUseAction += Use;
        
    }

    private void Update() {
        CheckGround();
        Movement();
    }

    private void Movement() {
        Vector2 inputVector =  gameInput.GetMovementVector();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, 0f);
        transform.position += moveDir * speedMove * Time.deltaTime;
    }

    private void Jump(object sender, System.EventArgs e) {
        if (playerIsGround == true) {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Use(object sender, System.EventArgs e) {
            OnPressUse?.Invoke(this, EventArgs.Empty);
    }

    private void CheckGround() {
        playerIsGround = player.PlayerIsGround;
    }
}
