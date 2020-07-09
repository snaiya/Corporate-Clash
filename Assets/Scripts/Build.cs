using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    public GameObject Panel;
    public GameObject BldgPanel;
    
    GameObject tutorialtext;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            tutorialtext = GameObject.Find("Tutorialtext");
            tutorialtext.GetComponent<Text>().text = "Make sure to purchase at least one tile before you construct a building";


            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
        if (BldgPanel != null)
        {
            BldgPanel.SetActive(false);
        }
    }
    
    public void OpenBuyBldg()
    {
        if (Panel != null)
        {

            tutorialtext = GameObject.Find("Tutorialtext");
            tutorialtext.GetComponent<Text>().text = "Select the type of building you wish to select";

            Panel.SetActive(false);
        }
        if (BldgPanel != null)
        {
            BldgPanel.SetActive(true);
        }
    }
    public void Close()
    {

    }
    public void Purchased()
    {
        /*Panel.SetActive(false);
        foreach (KeyValuePair<string, List<string>> kvp in variable.tiles_selected)
        {
            foreach (string s in kvp.Value)
            {
                GameObject pqr = GameObject.Find(s);
                pqr.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }*/

    }
    public void Canceled()
    {
        Panel.SetActive(false);

    }
}
