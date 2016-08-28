using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InspectPanelBehavior : MonoBehaviour {


	public static InspectPanelBehavior Instance;

	public Image imagePanel;
	public Text traitText;
	public Text attributeText;
	public Text nameText;

	void Awake () {
		Instance = this;
		this.gameObject.SetActive (false);
	}
		
	public void SetImage(Sprite img){
		imagePanel.sprite = img;
	}

	public void SetTraitText(string s){
		traitText.text = s;
	}

	public void SetAttrText(string s){
		attributeText.text = s;
	}

	public void SetNameText(string s){
		nameText.text = "Name: "+ s;
	}

}
