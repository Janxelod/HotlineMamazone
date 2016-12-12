using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputManager : MonoBehaviour
{
    private bool draggingItem = false;
    private GameObject draggedObject;
    private Vector2 touchOffset;
	public  RectTransform limitUp;
	public RectTransform limitDown;
	void Update ()
	{
	    if (HasInput)
	    {
	        DragOrPickUp();
	    }
	    else
	    {
	        if (draggingItem)
	            DropItem();
	    }
	}
    Vector2 CurrentTouchPosition
    {
        get
        {
           return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;
        if (draggingItem)
        {
			//if(draggedObject.GetComponent<PanelDragBehavior>().draggingItem) 
			{
				Vector2 newPosition = inputPosition + touchOffset;
				draggedObject.transform.position = new Vector3(newPosition.x,newPosition.y,0);
				Vector3 anchoredPosition = draggedObject.GetComponent<RectTransform>().anchoredPosition3D;
				float width = draggedObject.GetComponent<RectTransform>().rect.width * draggedObject.GetComponent<RectTransform>().localScale.x;
				float height = draggedObject.GetComponent<RectTransform>().rect.height * draggedObject.GetComponent<RectTransform>().localScale.y;
				float newPosX = Mathf.Clamp(anchoredPosition.x,limitDown.anchoredPosition3D.x + (width/2), limitUp.anchoredPosition3D.x - (width/2));
				float newPosY = Mathf.Clamp(anchoredPosition.y,limitDown.anchoredPosition3D.y + (height/2), limitUp.anchoredPosition3D.y - (height/2));

				draggedObject.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(newPosX, newPosY, 0);
				draggedObject.transform.SetAsLastSibling();
				//draggedObject.transform.Translate(touchOffset,Space.World);//.anchoredPosition = newPosition;
			}
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null)
                {
					
                    draggedObject = hit.transform.gameObject;
					//draggedObject.GetComponent<PanelDragBehavior>().draggingItem = true;
					draggingItem = true;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                    //draggedObject.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                }
            }
        }
    }
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }
    void DropItem()
    {
        draggingItem = false;
       // draggedObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
