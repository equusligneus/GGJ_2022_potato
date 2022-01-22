using System;
using UnityEngine;

public delegate void OnChangedCallback<T>(T _value);

public class RuntimeVar<T> : ScriptableObject, IEquatable<T>, IEquatable<RuntimeVar<T>>
{
	[SerializeField]
	private T defaultValue = default;

	public T Value { get; private set; }

	public event OnChangedCallback<T> OnValueChanged;

	private void OnEnable()
		=> Value = defaultValue;

	public void SetValue(T _value)
	{
		if (Equals(_value))
			return;

		Value = _value;
		if (OnValueChanged != default)
			OnValueChanged(_value);
	}

	public bool Equals(T _other)
	{
		if (typeof(T).IsValueType)
			return _other.Equals(Value);

		return ReferenceEquals(_other, Value);
	}

	public bool Equals(RuntimeVar<T> _other)
	{
		if (ReferenceEquals(_other, null))
			return false;

		if (ReferenceEquals(_other, this))
			return true;

		return Equals(_other.Value);
	}
}
