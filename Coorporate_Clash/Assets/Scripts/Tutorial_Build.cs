using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_Build : MonoBehaviour
{
	GameObject tile_color;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <= 23; i++)
        {
            tile_color = GameObject.Find("LuxuryTile" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }

        for (int i = 0; i <= 43; i++)
        {
            tile_color = GameObject.Find("Alleyway" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
        }

        for (int i = 0; i <= 71; i++)
        {
            tile_color = GameObject.Find("Street" + i.ToString());
            tile_color.gameObject.GetComponent<SpriteRenderer>().color = new Color(76.5f, 69f, 56.90f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
