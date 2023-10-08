using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingScript : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float alpha, velocity, targetAlpha = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alpha = Mathf.SmoothDamp(0.5f, targetAlpha, ref velocity, 0.1f, 1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alpha = Mathf.SmoothDamp(1f, targetAlpha, ref velocity, 0.1f, 1f);
        spriteRenderer.color = new Color(1, 1, 1, alpha);
    }
}
