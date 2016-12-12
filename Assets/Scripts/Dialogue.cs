using UnityEngine;
using System.Collections;
using System;

public class Dialogue {

	public int positiveScore;
	public int negativeScore;
	public int mediumScore;
	public string questionMessage;
	public string eventName;
	public string[] questionMessageSplit;
	public Difficulty levelDifficulty;
	public Department departmentDestiny; 
	public Department departmentSoSoDestiny;
	public int audioQuantity;
	public AudioClip[] audioList;
	public int currentAudio;
	// Use this for initialization
	public Dialogue(string eventName,int audioQuantity, Difficulty dificult, string depaBon, string depaMoy, string questionMessage, int positive, int negative){
		this.levelDifficulty = dificult;
		this.audioQuantity = audioQuantity;
		this.departmentDestiny = AssignDepartment(depaBon);
		this.departmentSoSoDestiny = AssignDepartment(depaMoy);
		this.questionMessage = questionMessage;
		this.positiveScore = positive;
		this.negativeScore = negative;
		this.eventName = eventName;
		this.questionMessageSplit = splitQuestionMessage(this.questionMessage);
		this.currentAudio = 0;
		SetAudioList();
	}
	public float getCurrentDialogueLenght(){
		return audioList[currentAudio].length;
	}
	public void SetAudioList(){
		audioList = new AudioClip[audioQuantity];
		AudioClip audioTemp = null;
		for (int i = 0; i < audioQuantity; i++) {
			string audioName = eventName+"_"+(i+1).ToString();
			string audioPath = "Sounds/Dialogue/"+audioName;
			audioTemp = Resources.Load(audioPath) as AudioClip;
			if(audioTemp!=null){
				audioList[i] = audioTemp;
				//Debug.Log("name: "+audioName+" , duration: "+audioTemp.length);
			}else{
				//Debug.Log(audioPath);
			}
		}
	}
	public void playAudio(AudioSource  audioSource){
		audioSource.clip = audioList[currentAudio];
		audioSource.Play();
		currentAudio++;
	}
	public string[] splitQuestionMessage(string question) {
		string[] stringSeparators = new string[] {"@"};
		string[] result;

		result = question.Split(stringSeparators, StringSplitOptions.None);
		string messages = "";
		foreach (string item in result) {
			messages+=" ["+item+"] ";
		}
		return result;
		//Debug.Log (messages);
	}
	//Level1: Easy ---> Level3: Hard
	public enum Difficulty{
		Level1,
		Level2,
		Level3
	}
	public Department AssignDepartment(string depa) {
		Department depaAssigned = Department.None;
		switch(depa){
			case "sh": depaAssigned = Department.ShippingService; break;
			case "se": depaAssigned = Department.SellingDepartment; break;
			case "te": depaAssigned = Department.TechnicalSupport; break;
			case "ma": depaAssigned = Department.Manager; break;
			case "af": depaAssigned = Department.AfterSaleServices; break;
			case "on": depaAssigned = Department.OnHold; break;
		}
		return depaAssigned;
	}
	public enum Department
	{
		None = 0,
		ShippingService = 1,//sh
		SellingDepartment = 2,//se
		TechnicalSupport = 3,//te
		Manager = 4,//ma
		AfterSaleServices = 5,//af
		OnHold = 6//on
	}
}
