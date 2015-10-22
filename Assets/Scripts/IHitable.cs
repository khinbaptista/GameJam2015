using UnityEngine;
using System.Collections;

public interface IHitable{
	float CurrentHp { get; }
	bool IsDead { get; }

	void OnHit(float damage, float poison = 0);
}
