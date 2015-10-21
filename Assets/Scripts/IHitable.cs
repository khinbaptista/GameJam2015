using UnityEngine;
using System.Collections;

public interface IHitable{
	float MaxHp { get; }

	void OnHit(float damage);
}
