using UnityEngine;

[RequireComponent(typeof(LevelStateWatcher))]
public class ExitLevelScript : MonoBehaviour
{
    [SerializeField] private RuntimeInt potatoCountRef;
    [SerializeField] private Level nextLevel;
    [SerializeField] private RuntimeLevel levelRef;

    [SerializeField] private GameObject exitBlocker;

    // Start is called before the first frame update
    void Start()
    {
        if (!potatoCountRef)
            return;

		potatoCountRef.OnValueChanged += PotatoCountRef_OnValueChanged;
        PotatoCountRef_OnValueChanged(potatoCountRef.Value);
    }

	private void OnDestroy()
	{
        if (potatoCountRef)
            potatoCountRef.OnValueChanged -= PotatoCountRef_OnValueChanged;
	}

	private void PotatoCountRef_OnValueChanged(int _value)
	{
        if (exitBlocker)
            exitBlocker.SetActive(_value > 0);
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        if (!potatoCountRef || potatoCountRef.Value > 0)
            return;

        if (!levelRef || !collision.gameObject.GetComponent<Player>())
            return;

        levelRef.SetValue(nextLevel);
	}
}
