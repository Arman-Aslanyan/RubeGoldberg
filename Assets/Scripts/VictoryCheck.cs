using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryCheck : MonoBehaviour
{
    private Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt = GameObject.Find("Canvas").GetComponentInChildren<Text>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            txt.enabled = true;
        }
    }
}
