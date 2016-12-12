using UnityEngine;
using System.Collections;

public class ButtonManagerScript : MonoBehaviour {

	public GameObject startPanel;
	public GameObject myPC;
	public GameObject myDocuments;
	public GameObject myRecycleBin;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ClickButton(string key){
		switch(key){
			case "Start": startPanel.SetActive(true); break;
			case "StartFromPanel": startPanel.SetActive(false); break;
			case "PCDenied": myPC.SetActive(true); myPC.transform.SetAsLastSibling(); break;
			case "MyDocumentsDenied": myDocuments.SetActive(true); myDocuments.transform.SetAsLastSibling(); break;
			case "MyRecycleDenied": myRecycleBin.SetActive(true); myRecycleBin.transform.SetAsLastSibling(); break;
		}
	}
}
