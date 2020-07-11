using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Estimate : MonoBehaviour
{
	public GameObject obj;
	public int indicator = 0;

	public List<GameObject> l = new List<GameObject>();
	public List<GameObject> a = new List<GameObject>();
	public List<GameObject> s = new List<GameObject>();

	public GameObject Text;

	public GameObject Area;

    // Start is called before the first frame update
    void Start()
    {

    	Text = GameObject.Find("Location");

    	Area = GameObject.Find("Area");

    	populate();
    }

    void populate()
    {
   
        string luxury = "LuxuryTile";
        for(int i = 0; i <=23 ; i++){
        	obj = GameObject.Find(luxury + i);
        	// add it to list
        	l.Add(obj);
        }
        
        string Alleyway = "Alleyway";
        for(int i = 0; i <=43 ; i++){
        	obj = GameObject.Find(Alleyway + i);
        	// add it to list
        	a.Add(obj);
        }

        string street = "Street";
        for(int i = 0; i <=71 ; i++){
        	obj = GameObject.Find(street + i);
        	// add it to list
        	s.Add(obj);

        }

        

        foreach(GameObject g in l){
        	g.AddComponent<cakeslice.Outline>();
        }

        Area.GetComponent<Text>().text = "Luxury";
        Text.GetComponent<Text>().text = @"-Prime Center! -Purchasing a land here is an expensive affair -Very well connected and Accessibile.";

        indicator+= 1;

	}

	    // Update is called once per frame
    public void onClick()
    {
        if (indicator==1){

        	foreach(GameObject g in l){
        		//scrpt = g.GetComponent<cakeslice.Outline>();
        		Destroy(g.GetComponent<cakeslice.Outline>());
        	}

        	foreach(GameObject g in a){
        		g.AddComponent<cakeslice.Outline>();
        	}

			Area.GetComponent<Text>().text = "Alleyway";
        	Text.GetComponent<Text>().text = @"-Close proximity to the Luxury Zone. -Decent amount of Consumer Footfall. -Purchasing a land here would cost a moderate amount";
        	indicator+=1;
        }

        else if(indicator==2) {

        	foreach(GameObject g in a){
        		//scrpt = g.GetComponent<cakeslice.Outline>();
        		Destroy(g.GetComponent<cakeslice.Outline>());
        	}

        	foreach(GameObject g in s){
        		g.AddComponent<cakeslice.Outline>();
        	}

        	Area.GetComponent<Text>().text = "Street";
        	Text.GetComponent<Text>().text = @"-Widely Spreadout. -Purchasing a tile here will not cost you a lot as it is far off from the hustle of the Luxury Zone ";
        	indicator+=1;
        }

        else if(indicator==3) {

        	UnityEngine.SceneManagement.SceneManager.LoadScene("TargetWindow");
        }
    }

}
