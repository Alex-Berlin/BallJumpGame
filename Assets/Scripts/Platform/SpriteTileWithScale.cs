using UnityEngine;

namespace BallJump.Platform
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteTileWithScale : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Transform tf;
        private void Start()
        {
            TryGetComponent(out spriteRenderer);
            TryGetComponent(out tf);
        }

        private void Update()
        {
            spriteRenderer.size = new Vector2(tf.lossyScale.x, 5);
        }
    }
}
