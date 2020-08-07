using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundChecker))]
public class GravityController : MonoBehaviour
{
    //On tap, changes gravity direction on opposite.

    [SerializeField][Range(0f, 500f)] private float gravityScale = 5f;
    public event Action OnGroundLeave;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && GroundChecker.isGrounded)
        {
            rb.gravityScale = -Math.Sign(rb.gravityScale) * DifficultyModifier.CurrentDifMod * gravityScale;
            OnGroundLeave?.Invoke();
        } 
    }



}