using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher), typeof(Collider2D))]
public class CollisionChange : MonoBehaviour
{
    public World activeDuring;

	private LevelStateWatcher watcher;
	private new Collider2D collider;

	private void Start()
	{
		watcher = GetComponent<LevelStateWatcher>();
		collider = GetComponent<Collider2D>();
		watcher.OnWorldChange += Watcher_OnWorldChange;
		Watcher_OnWorldChange(watcher.CurrentWorld);
	}

	private void Watcher_OnWorldChange(World _world)
	{
		collider.enabled = activeDuring == _world;
		Debug.LogFormat("{0} set collision to {1}", name, collider.enabled);
	}
}
