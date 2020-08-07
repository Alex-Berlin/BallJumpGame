using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundChecker : MonoBehaviour
{
    //Checks whether the player touches ground or not. 

    public event Action OnGroundTouch;
    public static bool isGrounded = false;
    [SerializeField] private bool CoyoteTimeEnabled; //coyote time adds a little bit of time for player to tap after they ran off the platform, making the game more forgiving
    [SerializeField] private float CoyoteTime = 0.05f; //in seconds

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        OnGroundTouch?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CoyoteTimeEnabled)
        {
            Invoke(nameof(ToggleGroundedToFalse), CoyoteTime);
        } else
        {
            isGrounded = false;
        }

    }

    private void ToggleGroundedToFalse()
    {
        isGrounded = false;
    }




}