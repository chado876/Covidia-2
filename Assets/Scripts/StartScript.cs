using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
	public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
		btn.onClick.AddListener(SwitchScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void SwitchScene(){
		Debug.Log("YES");
		Application.LoadLevel("GameScene");
	}
}
