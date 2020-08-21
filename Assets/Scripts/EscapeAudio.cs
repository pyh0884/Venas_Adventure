using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeAudio : MonoBehaviour
{
    public GameObject mainMenu;
    public AudioSource click;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(true);
            click.Play();
            this.gameObject.SetActive(false);
        }
    }
}
