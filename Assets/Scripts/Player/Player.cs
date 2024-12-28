using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDir;
    bool isRunning = false;
    [Header("Player Movement")]
    public float walkSpeed = 7;
    public float runSpeed = 11;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void GetMove(InputAction.CallbackContext ctx)
    {
        moveDir = ctx.ReadValue<Vector2>();
    }

    public void GetRun(InputAction.CallbackContext ctx)
    {
        isRunning = ctx.performed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isRunning)
            rb.linearVelocity = moveDir * walkSpeed;
        else
            rb.linearVelocity = moveDir * runSpeed;
    }
}
