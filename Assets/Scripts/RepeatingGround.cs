using UnityEngine;
using System.Collections;

public class RepeatingGround : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundLength;

    // Use this for initialization
    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundLength = groundCollider.size.x;
    }

    void Update()
    {
        // transform??（移动的偏移量）
        if (transform.position.x < -groundLength)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        // 往右移动2个宽度
        Vector2 groundOffset = new Vector2(groundLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
