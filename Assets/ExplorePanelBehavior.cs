using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ExplorePanelBehavior : MonoBehaviour {

	public static ExplorePanelBehavior Instance;

	public GameObject OptionButton;
	public GameObject OptionPanel;

	void Awake () {
		Instance = this;
		this.gameObject.SetActive (false);
	}

	public void Draw(ExplorationEvent currentEvent, ExploreState state){
		gameObject.GetComponentInChildren<Text> ().text = currentEvent.description;

			
		for (int i = 0; i < currentEvent.options.Count; i++) {
			GameObject button = Instantiate (OptionButton, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
			button.transform.SetParent (OptionPanel.transform);
			button.GetComponentInChildren<Text>().text = currentEvent.options [i].description;
			button.gameObject.GetComponent<OptionButtonBehavior> ().optionNum = i;
			button.gameObject.GetComponent<OptionButtonBehavior> ().state = state;

		}
				
		this.gameObject.transform.position = GameManager.Instance.transform.position;
		this.gameObject.SetActive (true);
	}

	public void Close(){
		this.gameObject.SetActive (false);

		foreach(Transform b in OptionPanel.transform){
			Destroy(b.gameObject);
		}

	}
}
