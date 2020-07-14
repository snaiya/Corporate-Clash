using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tutorial : MonoBehaviour
{
	public GameObject tutorialtext;
	public GameObject Image;
	public GameObject button;
	public GameObject button_i;
	public GameObject panel;
	public GameObject Health_bar;
	//public Button buildtile;

	int i;
	
    // Start is called before the first frame update
    void Start()
    {

    	if(variable.round < 2){

    	//button_i = GameObject.Find("Button-i");
    	button = GameObject.Find("ButtonOK");
    	button.SetActive(true);
    	//button_i.SetActive(false);


		Image = GameObject.Find("Image");
		Image.SetActive(false);

		tutorialtext = GameObject.Find("Tutorialtext");
        tutorialtext.GetComponent<Text>().text = "The highlighted tiles are the allocated land permits"; 
    }
    if(variable.round >=2){
    	button = GameObject.Find("ButtonOK");
    	button.SetActive(false);
    	panel = GameObject.Find("InstructionPanel");
    	

    }
    if(variable.round == 2 || variable.round == 5 || variable.round == 8 || variable.round == 11){
    	tutorialtext = GameObject.Find("Tutorialtext");
        tutorialtext.GetComponent<Text>().text = "UNPURCHASED TILES WILL NOT BE AVAILABLE AFTER THIS ROUND"; 

    }


        i=0;
		//buildtile = GameObject.Find("Button-Tile");
    }

	public void onClick()
	{
		button = GameObject.Find("ButtonOK");
    	button.SetActive(false);
		Image.SetActive(true);
		Health_bar.SetActive(true);
		//Image.AddComponent<cakeslice.Outline>();
		
		if (i==0)
		{
			tutorialtext.GetComponent<Text>().text = "To buy the tiles click on the Start Building button above";
			i+=1;
		}
		//buildtile.Select();
		//buildtile.OnSelect(null);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
