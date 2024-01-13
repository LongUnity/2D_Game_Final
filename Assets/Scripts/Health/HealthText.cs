using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Vector3 moveSpeed;
    [SerializeField] private float timeToFade;

    TextMesh textMeshPro;

    private float timeElapsed;
    private Color startColor;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        textMeshPro = GetComponent<TextMesh>();
        startColor = textMeshPro.color;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position += moveSpeed * Time.deltaTime;
        timeElapsed += Time.deltaTime;
        if (timeElapsed < timeToFade)
        {
            float fadeAlpha = startColor.a * (1 - timeElapsed / timeToFade);
            textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, fadeAlpha);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
