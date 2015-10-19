using UnityEngine;
using System.Collections;

public interface IHitable{
	float HP { get; }

	void OnHit(float damage);
}
