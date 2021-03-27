using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
	public int scoreAmount = 0;


	// when collided with another gameObject
	void OnCollisionEnter(Collision newCollision)
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm)
		{
			if (GameManager.gm.gameIsOver)
				return;
		}

		// only do stuff if hit by a projectile
		if (newCollision.gameObject.tag == "Projectile")
		{
			GameManager.gm.targetMiss(scoreAmount);
			//GameManager.gm.ScoreReset();

		}
		 


	}
}