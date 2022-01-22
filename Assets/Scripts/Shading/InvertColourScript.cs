using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertColourScript : MonoBehaviour
{
    public RuntimeWorld worldRef;
    public Material material;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
        if (worldRef && worldRef.Value == World.Alternative)
            Graphics.Blit(source, destination, material);
        else
            Graphics.Blit(source, destination);
	}
}
