using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Player))]
public class FocusAbility<T> : MonoBehaviour where T : Focusable
{
    [SerializeField] protected RuntimeGrid currentGrid;
    [SerializeField] protected RuntimeInt2 currentPositionRef;
    [SerializeField] protected RuntimeInt2 currentDirectionRef;

    protected Player player;
    protected T currentFocus;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = GetComponent<Player>();
    }

    protected virtual void Update()
    {
        var focusable = player.CanFocus ? currentGrid.Value.GetComponentAt<T>(currentPositionRef.Value + currentDirectionRef.Value) : default;

        if (focusable == currentFocus)
            return;

        if (currentFocus)
            currentFocus.Blur();

        currentFocus = focusable;

        if (currentFocus)
            currentFocus.Focus();
    }
}
