using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D))]
public class RemovableBlock : Switchable
{
	private new SpriteRenderer renderer;
	private new BoxCollider2D collider;
	public bool removeOnActivate = true;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		collider = GetComponent<BoxCollider2D>();
	}

	public override void Switch(bool _on)
	{
		renderer.enabled = _on != removeOnActivate;
		collider.enabled = _on != removeOnActivate;
	}
}
