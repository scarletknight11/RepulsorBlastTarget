using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;

	// public variables
	public int score=0;

	public bool canBeatLevel = false;
	public int beatLevelScore=0;

	public TextMeshProUGUI mainScoreDisplay;
 
	public GameObject gameOverScoreOutline;

	public AudioSource musicAudioSource;

	public bool gameIsOver = false;

	public GameObject wincanvas;

	public int hitcounter;

	public GameObject bonusmessage;


	// setup the game
	void Start () {
		// get a reference to the GameManager component for use by other scripts
		if (gm == null) 
			gm = this.gameObject.GetComponent<GameManager>();

		// init scoreboard to 0
		mainScoreDisplay.text = "0";

		// inactivate the gameOverScoreOutline gameObject, if it is set
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (false);

         

        // inactivate the nextLevelButtons gameObject, if it is set
        if (wincanvas)
			wincanvas.SetActive(false);
    }

	// this is the main game event loop
	void Update () {
		if (!gameIsOver) {
			if (canBeatLevel && (score >= beatLevelScore)) {  // check to see if beat game
				BeatLevel ();
			} 
		}
	}

	void EndGame() {
		// game is over
		gameIsOver = true;

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);
	
		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}
	
	void BeatLevel() {
		// game is over
		gameIsOver = true;

		// activate the gameOverScoreOutline gameObject, if it is set 
		if (gameOverScoreOutline)
			gameOverScoreOutline.SetActive (true);

		// activate the nextLevelButtons gameObject, if it is set 
		if (wincanvas)
			wincanvas.SetActive(true);

		// reduce the pitch of the background music, if it is set 
		if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	// public function that can be called to update the score or time
	public void targetHit (int scoreAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		hitcounter += 1;
		Debug.Log("Hitcounter " + hitcounter);
		if (hitcounter == 3)
        {
			hitcounter = 0;
			BonusHit();
		}
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
	}

	public void targetMiss(int scoreAmount)
	{
		// decrease the score by the scoreAmount and update the text UI
		//score -= scoreAmount;
		hitcounter = 0;
		Debug.Log("Hitcounter " + hitcounter);
		//mainScoreDisplay.text = score.ToString();
		//if (score <= 0)
		//{
		//	score = 0;
		//	mainScoreDisplay.text = score.ToString();
		//}
	}

	public void BonusHit()
	{
		// increase the score by the scoreAmount and update the text UI
		score += 3;
		mainScoreDisplay.text = score.ToString();
		bonusmessage.SetActive(true);
		StartCoroutine(Message());
	}

	IEnumerator Message()
    {
		yield return new WaitForSeconds(5);
		bonusmessage.SetActive(false);
	}
}
