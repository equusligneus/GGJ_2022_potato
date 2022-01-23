using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher))]
public class PotatoPickUp : MonoBehaviour
{
	[SerializeField] AudioSource myAudioSource;
    [SerializeField] RuntimeInt potatoCountRef;
	LevelStateWatcher watcher;

	private bool initialised = false;


	private void Start()
	{
		watcher = GetComponent<LevelStateWatcher>();
		myAudioSource = GetComponent<AudioSource>();

		watcher.OnLevelChange += Watcher_OnLevelChange;
	}

	private void Watcher_OnLevelChange(Level obj)
	{
		if (initialised || !watcher.IsInLevel)
			return;

		potatoCountRef.SetValue(potatoCountRef.Value + 1);
		initialised = true;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("Potato is triggered!!!");
		if (collision.gameObject.GetComponent<Player>())
			potatoCountRef.SetValue(potatoCountRef.Value - 1);

		myAudioSource.Play();
		GetComponent<SpriteRenderer>().enabled = false;
		GetComponent<Collider2D>().enabled = false;
	}
}
