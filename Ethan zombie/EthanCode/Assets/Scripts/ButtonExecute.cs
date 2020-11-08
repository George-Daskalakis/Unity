using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;


public class ButtonExecute : MonoBehaviour {
	
	
	private GameObject currentButton;
	private float timeToSelect = 2.0f;
	private float countDown;
	
	void Update () {
		Transform camera = Camera.main.transform;
		Ray ray = new Ray (camera.transform.position, camera.rotation * Vector3.forward);
		RaycastHit hit;
		GameObject hitButton = null;
		PointerEventData data = new PointerEventData (EventSystem.current);
		
		if (Physics.Raycast (ray, out hit)) {
			if (hit.transform.gameObject.tag == "Button") {
				hitButton = hit.transform.parent.gameObject;
			}
		}
		if (currentButton != hitButton) {
			if (currentButton != null) { // unhighlight
				ExecuteEvents.Execute<IPointerExitHandler> (currentButton, data, ExecuteEvents.pointerExitHandler);
			}
			currentButton = hitButton;
			if (currentButton != null) { // highlight
				ExecuteEvents.Execute<IPointerEnterHandler> (currentButton, data, ExecuteEvents.pointerEnterHandler);
			}
		}
		if (currentButton != null) {
			//if (clicker.clicked()) { 
			//ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerCLickHandler);
			//}
		countDown -= Time.deltaTime;
		if(countDown < 0.0f) {
			ExecuteEvents.Execute<IPointerClickHandler>(currentButton, data, ExecuteEvents.pointerClickHandler);
			countDown = timeToSelect;
			}
		}
}
}