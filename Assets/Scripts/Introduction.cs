using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Introduction : MonoBehaviour
{
    public GameObject introduction;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
           introduction.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>() != null)
        {
            introduction.SetActive(false);
        }
    }
}
