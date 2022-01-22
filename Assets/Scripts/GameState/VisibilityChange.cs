using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher), typeof(SpriteRenderer))]
public class VisibilityChange : MonoBehaviour
{
	public World activeDuring;

	private LevelStateWatcher watcher;
	private new SpriteRenderer renderer;

	private void Start()
	{
		watcher = GetComponent<LevelStateWatcher>();
		renderer = GetComponent<SpriteRenderer>();
		watcher.OnWorldChange += Watcher_OnWorldChange;
		Watcher_OnWorldChange(watcher.CurrentWorld);
	}

	private void Watcher_OnWorldChange(World _world)
	{
		renderer.enabled = activeDuring == _world;
		Debug.LogFormat("{0} set renderer to {1}", name, renderer.enabled);
	}
}
