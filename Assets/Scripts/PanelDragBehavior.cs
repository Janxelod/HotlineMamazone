using UnityEngine;
using UnityEngine.UI;

public class PanelDragBehavior : MonoBehaviour
{
	
	public Vector3 currentPosition;
	public bool madeCollision;
	public bool draggingItem;
	public bool isBody;
	public void FixedUpdate(){
			currentPosition = transform.position;
	}
	void OnTriggerEnter2D(Collider2D collision) {
		/*foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}*/
		if(collision.name=="Limit"){
			transform.position = currentPosition;
			draggingItem = false;
		}
		//Debug.Log("OnTriggerEnter2D");
	}
	void OnTriggerExit2D(Collider2D collision) {
		/*foreach (ContactPoint contact in collision.contacts) {
			Debug.DrawRay(contact.point, contact.normal, Color.white);
		}*/
		if(collision.name=="Limit"){
			transform.position = currentPosition;
			draggingItem = true;
		}
		//Debug.Log("OnTriggerExit2D");
	}
	void OnMouseDown() {
		if(GameObject.Find("StartPanel") != null){
			GameObject.Find("StartPanel").SetActive(false);
		}
	}
	public void ClickPanel(string buttonComand){
		if(buttonComand == "close"){
			transform.gameObject.SetActive(false);
		}
	}
}