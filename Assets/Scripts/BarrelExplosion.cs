using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : MonoBehaviour
{
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter(Collision newCollision)
	{
		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile")
		{
			if (explosionPrefab)
			{
				// Instantiate an explosion effect at the gameObjects position and rotation
				Instantiate(explosionPrefab, transform.position, transform.rotation);
			}

			// destroy the projectile
			Destroy(newCollision.gameObject);

			// destroy self
			Destroy(gameObject);
		}
	}
}
