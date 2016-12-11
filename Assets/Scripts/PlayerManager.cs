using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public int currentScore;
	public enum States{
		AnswerThePhone = 1,
		MakeACall = 2,
		None = 3
	}
	public States currentState;
	public bool answerThePhone;
	public bool makeAcall;
	// Use this for initialization
	void Start () {
		currentState = States.None;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddScore(int score) {
		currentScore += score;
	}
}
