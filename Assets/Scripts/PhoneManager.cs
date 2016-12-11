using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PhoneManager : MonoBehaviour {
	public GameObject phoneNumber;
	public GameObject phoneMessage;
	public Dictionary<string, Dialogue.Department> departmentPhoneList;
	public bool isCalling;
	public bool inCall;
	public Dialogue currentDialogue;
	public PlayerManager playerManager;
	public enum PhoneCallState{
		Correct = 1,
		Incorrect = 2,
		Nothing = 3
	}
	public PhoneCallState currentPhoneCallState;
	// Use this for initialization
	void Start () {
		phoneNumber = GameObject.Find("PhoneNumber");
		playerManager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
		departmentPhoneList =new Dictionary<string, Dialogue.Department>();
		departmentPhoneList.Add("235",Dialogue.Department.AfterSaleServices);
		departmentPhoneList.Add("352",Dialogue.Department.TechnicalSupport);
		departmentPhoneList.Add("666",Dialogue.Department.Manager);
		departmentPhoneList.Add("313",Dialogue.Department.SellingDepartment);
		departmentPhoneList.Add("240",Dialogue.Department.ShippingService);
		departmentPhoneList.Add("404",Dialogue.Department.OnHold);
		departmentPhoneList.Add("000",Dialogue.Department.None);
		Dialogue.Department newDepartment = Dialogue.Department.None;
		if(departmentPhoneList.ContainsKey("666")) {
			Debug.Log(departmentPhoneList["666"]);
		}
		if(departmentPhoneList.ContainsKey("352")) {
			Debug.Log(departmentPhoneList["352"]);
		}
		isCalling = false;
		inCall = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CallPartner(string number){
		if(departmentPhoneList.ContainsKey(number)){
			if((int)departmentPhoneList[number] == (int)currentDialogue.departmentDestiny){
				Debug.Log("EXCELLENT!!");
				currentPhoneCallState = PhoneCallState.Correct;
				playerManager.AddScore(currentDialogue.positiveScore);
			}else {
				playerManager.AddScore(currentDialogue.negativeScore);
				currentPhoneCallState = PhoneCallState.Incorrect;
				Debug.Log("INCORRECT!!!");
			}
		}else {
			playerManager.AddScore(currentDialogue.negativeScore);
			currentPhoneCallState = PhoneCallState.Nothing;
			Debug.Log("SUPER INCORRECT!!!");
		}
	}
	public void ClickPhone(string key){
		Text phoneText = phoneNumber.GetComponent<Text>();
		string phoneTextString = phoneText.text;
		if(key == "enter"){
			if(isCalling) {
				phoneNumber.SetActive(true);
				phoneMessage.GetComponent<Animator>().SetBool("calling",false);
				playerManager.answerThePhone = true;
				playerManager.currentState = PlayerManager.States.AnswerThePhone;
				//isCalling = false;
			}else {
				if(inCall) {
					playerManager.currentState = PlayerManager.States.MakeACall;
					//playerManager.makeAcall = true;
					CallPartner(phoneTextString);		
				}
			}
		}else{
			if(key == "delete") {
				if(phoneTextString.Length>=1) {
					phoneTextString = phoneTextString.Substring(0,phoneTextString.Length-1);
					phoneText.text = phoneTextString;	
				}
			}else{
				if(phoneTextString.Length<4){
					if(key != "enter"){
						phoneText.text = phoneTextString + key;
					}
				}
			}
		}
	}
	public void SetCurrentCall(Dialogue newDialogue) {
		currentDialogue = newDialogue;
		phoneMessage.GetComponent<Animator>().SetBool("calling",true);
		phoneNumber.SetActive(false);
		isCalling = true;
	}
}
