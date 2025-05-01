using UnityEngine;
using UnityEngine.InputSystem;


public class BallPusher : MonoBehaviour
{
    private TouchInputs playerinputs; 
    public Rigidbody ball; 

    public float minSwipeDistance = 50f; 
    public float maxSwipeDuration = 1f; 
    private Vector2 startPos, endPos;
    private float startTime, endTime; 

    private void Awake()
    {
        playerinputs = new TouchInputs();
    }

    void Start()
    {
        playerinputs.Touch.PrimaryTouch.started += StartPrimaryTouch; 
        playerinputs.Touch.PrimaryTouch.canceled +=  EndPrimaryTouch; 
    }

    private void StartPrimaryTouch(InputAction.CallbackContext context)
    {
        startPos = playerinputs.Touch.PrimaryTouch.ReadValue<Vector2>();
        startTime = (float) context.time; 
    }

    private void EndPrimaryTouch(InputAction.CallbackContext context)
    {
        endPos = playerinputs.Touch.PrimaryTouch.ReadValue<Vector2>();
        startTime = (float)context.time; 

        if(Vector2.Distance(startPos, endPos) >= minSwipeDistance && (endTime - startTime) <= maxSwipeDuration) 
        {
            Vector2 aim = startPos - endPos;
            Swipe(aim);
        }
    }

    private void Swipe(Vector2 direction)
    {
        Debug.Log("[AR-DEBUG] Swipe called " + direction.x + " " + direction.y);
        ball.AddForce(new Vector3(direction.x * 10,0,direction.y * 10));
    }

    private void OnEnable()
    {
        playerinputs.Enable();
    }

    private void OnDisable()
    {
        playerinputs.Disable();
    }
}
