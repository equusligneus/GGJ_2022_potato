using AllIn1SpriteShader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Focusable : MonoBehaviour
{
    private new SpriteRenderer renderer;
    private const string outline_name = "_OutlineAlpha";

    protected virtual void Awake()
	{
        renderer = GetComponent<SpriteRenderer>();
	}

    public void Focus() 
    {
        renderer.material.SetFloat(outline_name, 1f);
    }

    public void Blur() 
    {
        renderer.material.SetFloat(outline_name, 0f);
    }
}
