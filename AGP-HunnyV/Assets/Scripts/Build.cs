using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    public GameObject Panel;
    public GameObject BldgPanel;
    public void OpenPanel()
    {
        if (Panel != null)
        {
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
