using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public int currentIndexDialogList;
	public int currentIndexDialogChar;
	public float frequencyPerChar;
	public Text dialogueTextReference;
	public int numLinesPerPage;
	public GameObject dialogueWindow;
	public ArrayList dialogueList;
	public Dialogue currentDialogue;
	public int currentDialogueIndex;
	public DialogueFactory factory;
	public AudioSource dialogueAudioSource;
	public char lastChar;
	// Use this for initialization
	void Start () {
		dialogueList = new ArrayList();
		currentDialogueIndex = 0;
		DialogueCreationTest();//Only for testing purpose
		dialogueAudioSource = GetComponent<AudioSource>();
	}
	public bool isEndGame(){
		return currentDialogueIndex  == dialogueList.Count;// == 6;//
	}
	public void StartNewDialogue(){
		dialogueWindow.SetActive(true);
		StartMessage();
	}
	public void StopDialogue(){
		dialogueWindow.SetActive(false);
		CancelInvoke();
	}
	// Update is called once per frame
	void Update () {
	
	}
	public void setNewDialogue() {
		currentDialogue = (Dialogue)dialogueList[currentDialogueIndex];
	}
	void DialogueCreationTest(){
		Dialogue diag = null;
		factory = new DialogueFactory();
		factory.ShuffleElements();
		dialogueList = factory.dialogueList;
	}

	void StartMessage() {
		dialogueTextReference = dialogueWindow.GetComponentInChildren<Text>();
		dialogueTextReference.text = "";
		currentIndexDialogList = 0;
		currentIndexDialogChar = 0;
		PlayCurrentPhrase();
		Invoke("ShowCharacters",frequencyPerChar);
	}

	void ShowCharacters(){
		if(currentIndexDialogList<currentDialogue.questionMessageSplit.Length) {
			string currentText = dialogueTextReference.text;
			if(currentIndexDialogChar<currentDialogue.questionMessageSplit[currentIndexDialogList].Length){
				lastChar = currentDialogue.questionMessageSplit[currentIndexDialogList][currentIndexDialogChar];
				if(lastChar!='$')
					currentText += lastChar;
				dialogueTextReference.text = currentText;
				currentIndexDialogChar++;
				Invoke("ShowCharacters",frequencyPerChar);
			}else{
				float frequePerLine = 0;
				if((currentIndexDialogList+1)%numLinesPerPage == 0) {
					frequePerLine = frequencyPerChar*20f;
					Invoke("DeletePage", frequePerLine);
					if(lastChar == '$') Invoke("PlayCurrentPhrase", frequePerLine);
				}else {
					currentText+='\n';
					frequePerLine = frequencyPerChar*10f;
					if(lastChar == '$') Invoke("PlayCurrentPhrase", frequePerLine);
					Invoke("ShowCharacters", frequePerLine);
				}
				dialogueTextReference.text = currentText;
				currentIndexDialogList++;
				currentIndexDialogChar = 0;
			}	
		}
	}
	void PlayCurrentPhrase(){
		if(currentIndexDialogList<currentDialogue.questionMessageSplit.Length) {
			string currentText = currentDialogue.questionMessageSplit[currentIndexDialogList];
			int currentDialoguePhraseLenght = 0;
			if(currentText[currentText.Length-1]=='$') {
				currentDialoguePhraseLenght = currentText.Length;	
			}else{
				int nextTextLength = 0;
				if(currentDialogue.questionMessageSplit.Length > currentIndexDialogList+1) {
					string nextText = currentDialogue.questionMessageSplit[currentIndexDialogList+1];
					nextTextLength = nextText.Length;
				}
					
				currentDialoguePhraseLenght = currentText.Length + nextTextLength;
			}

			frequencyPerChar = currentDialogue.getCurrentDialogueLenght()/currentDialoguePhraseLenght;
			currentDialogue.playAudio(dialogueAudioSource);	
		}
	}
	void DeletePage(){
		if(currentIndexDialogList<currentDialogue.questionMessageSplit.Length) {
			dialogueTextReference.text = "";
			Invoke("ShowCharacters",frequencyPerChar);	
		}
	}
}
