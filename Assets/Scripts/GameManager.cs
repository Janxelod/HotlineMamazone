using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public DialogueManager dialogueManager;
	public PhoneManager phoneManager;
	public PlayerManager playerManager;
	public MessengerPopupManager messengerPopUpManager;
	public ScoreManager scoreManager;
	public GameState currentState;
	public float waitTimeNextDialogue;
	public int currentMistakes;
	public int MAX_CURRENT_MISTAKE;
	public GamerOverManager gameOverManager;
	public InitGameManager initGameManager;
	public GameObject initBackground;
	public GameObject gameTitle;
	public GameObject backgroundTutoScreen;
	//public GameObject gameOverScreen;
	// Use this for initialization
	void Start () {
		dialogueManager = GetComponent<DialogueManager>();
		phoneManager = GetComponent<PhoneManager>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player!=null){
			playerManager = player.GetComponent<PlayerManager>();	
		}
		messengerPopUpManager = GameObject.Find("Messenger").GetComponent<MessengerPopupManager>();
		scoreManager = GameObject.Find("Score").GetComponent<ScoreManager>();
		currentState = GameState.None;
		//currentState = GameState.InitGame;
	}
	public void StartInitGame(){
		currentState = GameState.InitGame;
	}
	void Awake(){
		initBackground.SetActive(true);
		gameTitle.SetActive(true);
		backgroundTutoScreen.SetActive(true);
	}
	void StartGame() {
		InitCall();
		currentState = GameState.Calling;
	}
	void InitCall() {
		//dialogueManager.StartNewDialogue();
		phoneManager.isCalling = true;
		dialogueManager.setNewDialogue();
		phoneManager.SetCurrentCall(dialogueManager.currentDialogue);
	}
	void CallingState() {
		if(phoneManager.isCalling){
			if(playerManager.currentState == PlayerManager.States.AnswerThePhone) {
				dialogueManager.StartNewDialogue();
				playerManager.currentState = PlayerManager.States.None;
				phoneManager.inCall = true;
				currentState = GameState.InCall;
				phoneManager.isCalling = false;
			}
		}
	}
	void InCallState() {
		if(playerManager.currentState == PlayerManager.States.MakeACall) {
			switch(phoneManager.currentPhoneCallState) {
				case PhoneManager.PhoneCallState.Correct: 
					//Graphic and audioFeedback??
					currentState = GameState.ReinitManagers;
				break;
				default:
				{
					scoreManager.showMistake(currentMistakes);
					currentMistakes++;
					if(currentMistakes == MAX_CURRENT_MISTAKE) {
						currentState = GameState.None;
						dialogueManager.StopDialogue();
						CancelInvoke();
						Invoke("StartGameOverState",3.5f);
					}else {
						messengerPopUpManager.showMessengerPopUp();			
						currentState = GameState.ReinitManagers;
					}
				}
				break;
			}
			playerManager.currentState = PlayerManager.States.None;
			//currentState = GameState.ReinitManagers;
		}
	}
	void StartGameOverState() {
		currentState = GameState.GameOver;
	}
	void StartMediumEndingState() {
		currentState = GameState.MediumEnding;
	}
	//REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN 
	//REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN 
	//REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN 
	//REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN 
	//REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN //REGARDER DEMAIN 
	void ReinitManagersState() {
		dialogueManager.StopDialogue();
		dialogueManager.currentDialogueIndex++;
		if(dialogueManager.isEndGame()){
			dialogueManager.StopDialogue();
			CancelInvoke();
			currentState = GameState.None;
			Invoke("StartMediumEndingState",3.5f);
			Debug.Log("Is end game");
		}else {
			currentState = GameState.None;
			Invoke("StartNewCall",waitTimeNextDialogue);	
		}
	}
	void StartNewCall() {
		currentState = GameState.InitGame;
	}
	// Update is called once per frame
	void Update () {
		switch(currentState) {
			case GameState.InitGame:
				StartGame();
			break;
			case GameState.Calling:
				CallingState();
			break;
			case GameState.InCall:
				InCallState();
			break;
			case GameState.ReinitManagers:
				ReinitManagersState();
			break;
			case GameState.MediumEnding:
				StartMediumEnding();
				currentState = GameState.None;
			break;
			case GameState.GameOver:
				Debug.Log("Game Over");
				StartGameOver();
				currentState = GameState.None;
			break;
		}


		//Debug.Log(currentState);
	}
	void StartGameOver() {
		gameOverManager.StartGameOver();	
	}
	void StartMediumEnding(){
		Debug.Log ("Start medium ending");
		gameOverManager.StartMediumEnding();
	}
	public enum GameState{
		InitGame = 1,
		Calling = 2,
		InCall = 3,
		ReinitManagers = 4,
		GameOver = 5,
		MediumEnding = 6,
		None = 7
	}
}
