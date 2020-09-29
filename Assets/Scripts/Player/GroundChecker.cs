using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundChecker : MonoBehaviour
{
    //Checks whether the player touches ground or not. 

    public event Action OnGroundTouch;
    public bool IsGrounded = false;
    [Tooltip("Enable time delay till ground leave registers.")]
    [SerializeField] private bool coyoteTimeEnabled; //coyote time adds a little bit of time for player to tap after they ran off the platform, making the game more forgiving
    [SerializeField] private float coyoteTime = 0.05f; //in seconds

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
        OnGroundTouch?.Invoke();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (coyoteTimeEnabled)
        {
            Invoke(nameof(ToggleGroundedToFalse), coyoteTime);
        } else
        {
            IsGrounded = false;
        }

    }

    private void ToggleGroundedToFalse()
    {
        IsGrounded = false;
    }




}