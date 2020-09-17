using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour, RollABallControls.IPlayerActions
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public RollABallControls controls;
    private Rigidbody rb;
    private int count;
    private int lives;
    public Vector2 motion;
    // Comment
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        lives = 3;
        livesText.text= "Lives: " + lives.ToString ();
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
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive (false);
            int v = count + 1;
            count = v;
            SetCountText ();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }
        if (count == 12)
        {
    transform.position = new Vector3(50.0f, 0.0f, 50.0f); 
}
    }
    void SetCountText ()
    {
        countText.text= "Count: " + count.ToString ();
        if (count >= 20)
        {
            winText.text = "You Win! Jacob Brady";
        }
    }
    void SetLivesText ()
    {
        livesText.text= "Lives: " + count.ToString ();
    }
}