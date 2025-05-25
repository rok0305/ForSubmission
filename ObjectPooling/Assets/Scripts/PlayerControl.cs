using UnityEngine;

public class PlayerControl : MonoBehaviour // 그냥 풀링과 상관없는 네모의 움직임
{
    KeyCode jumpKeyCode = KeyCode.Space;

    private float jumpForce = 10;
    private float moveSpeed = 8;
    
    private Rigidbody2D rigid2D;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Move(x);
        if (Input.GetKeyDown(jumpKeyCode))
        {
            Jump();
        }
    }
    private void Jump()
    {
            rigid2D.linearVelocityY = jumpForce;
    }
    private void Move(float x)
    {
        rigid2D.linearVelocityX = x * moveSpeed;
    }
}
