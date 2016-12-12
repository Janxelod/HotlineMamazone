using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour {

	public Text timeText;
	// Use this for initialization
	void Start () {
		timeText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		timeText.text = System.DateTime.Now.ToString(" h:mm tt");

	}
}
