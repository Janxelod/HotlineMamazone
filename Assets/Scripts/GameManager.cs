using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	
	public DialogueManager dialogueManager;
	public PhoneManager phoneManager;
	public PlayerManager playerManager;
	public MessengerPopupManager messengerPopUpManager;
	public GameState currentState;
	public float waitTimeNextDialogue;
	// Use this for initialization
	void Start () {
		dialogueManager = GetComponent<DialogueManager>();
		phoneManager = GetComponent<PhoneManager>();
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(player!=null){
			playerManager = player.GetComponent<PlayerManager>();	
		}
		messengerPopUpManager = GameObject.Find("Messenger").GetComponent<MessengerPopupManager>();
		currentState = GameState.InitGame;

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
					//??
				break;
				default:
					messengerPopUpManager.showMessengerPopUp();
				break;
				/*case PhoneManager.PhoneCallState.Incorrect: 
					
				break;
				case PhoneManager.PhoneCallState.Nothing: 
					
				break;*/
			}
			//playerManager.makeAcall = false;
			playerManager.currentState = PlayerManager.States.None;
			currentState = GameState.ReinitManagers;
		}
	}
	void ReinitManagersState() {
		dialogueManager.StopDialogue();
		dialogueManager.currentDialogueIndex++;
		currentState = GameState.None;
		Invoke("StartNewCall",waitTimeNextDialogue);

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
			case GameState.GameOver:
				Debug.Log("Game Over");
				currentState = GameState.None;
			break;
		}
		//Debug.Log(currentState);
	}

	public enum GameState{
		InitGame = 1,
		Calling = 2,
		InCall = 3,
		ReinitManagers = 4,
		GameOver = 5,
		None = 6
	}
}
