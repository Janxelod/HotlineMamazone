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
	// Use this for initialization
	void Start () {
		dialogueList = new ArrayList();
		currentDialogueIndex = 0;
		DialogueCreationTest();//Only for testing purpose
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
		for (int i = 0; i < 10; i++) {
			diag = new Dialogue("Order Not recieved",3,Dialogue.Difficulty.Level1,"sh","ma",
				("DiagIndex:"+(i+1).ToString())+"Line 1 asdasdas,asdasda@Line 2 asdasdasdasda, asdasda@Line 3 1231232312321, asdas@Line 4 asdasda123123" +
				"@Line 5 asdasdas,asdasda@Line 6 asdasdasdasda, asdasda@Line 7 1231232312321, asdas@Line 8 asdasda123123" + 
				"@Line 9 asdasdas,asdasda@Line 10 asdasdasdasda, asdasda@Line 11 1231232312321, asdas@Line 12 asdasda123123" + 
				"@Line 13 asdasdas,asdasda@Line 14 asdasdasdasda, asdasda@Line 15 1231232312321, asdas@Line 16 asdasda123123"+("DiagIndex:"+(i+1).ToString())
				, 240, 111);
			dialogueList.Add(diag);
		}
	}

	void StartMessage() {
		dialogueTextReference = dialogueWindow.GetComponentInChildren<Text>();
		dialogueTextReference.text = "";
		currentIndexDialogList = 0;
		currentIndexDialogChar = 0;
		Invoke("ShowCharacters",frequencyPerChar);
	}

	void ShowCharacters(){
		if(currentIndexDialogList<currentDialogue.questionMessageSplit.Length) {
			string currentText = dialogueTextReference.text;
			if(currentIndexDialogChar<currentDialogue.questionMessageSplit[currentIndexDialogList].Length){
				currentText += currentDialogue.questionMessageSplit[currentIndexDialogList][currentIndexDialogChar];
				dialogueTextReference.text = currentText;
				currentIndexDialogChar++;
				Invoke("ShowCharacters",frequencyPerChar);
			}else{
				float frequePerLine = 0;
				if((currentIndexDialogList+1)%numLinesPerPage == 0) {
					//currentText = "";
					frequePerLine = frequencyPerChar*20f;
					Invoke("DeletePage", frequePerLine);
				}
				else {
					currentText+='\n';
					frequePerLine = frequencyPerChar*10f;
					Invoke("ShowCharacters", frequePerLine);
				}
				dialogueTextReference.text = currentText;
				currentIndexDialogList++;
				currentIndexDialogChar = 0;
			}	
		}
	}
	void DeletePage(){
		if(currentIndexDialogList<currentDialogue.questionMessageSplit.Length) {
			dialogueTextReference.text = "";
			Invoke("ShowCharacters",frequencyPerChar);	
		}
	}
}
