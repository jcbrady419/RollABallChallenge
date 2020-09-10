using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, RollABallControls.IPlayerActions
{
    public float speed;
    public RollABallControls controls;
    private Rigidbody rb;
    public Vector2 motion;
    // Comment
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnEnable() {
        if (controls == null)
        {
            controls = new RollABallControls();

            controls.Player.SetCallbacks(this);
        }
        controls.Player.Enable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        motion = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(motion.x, 0.0f, motion.y);
        rb.AddForce(movement*speed); 
    }
}