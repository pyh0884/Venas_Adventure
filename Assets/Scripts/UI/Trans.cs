using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Trans : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject DeadMenu;
    private Animator anim;
        void Start()
    {
        anim = GetComponent<Animator>();    
    }

    public void LoadScene(int number) 
    {
        StartCoroutine(LoadSceneFunction(number));      
    }

    IEnumerator LoadSceneFunction(int number) 
    {
        if (DeadMenu != null)
        {
            DeadMenu.SetActive(false);
        }

        if (PauseMenu != null)
        {
            PauseMenu.SetActive(false);
        }

        Time.timeScale = 1;
        anim.SetTrigger("End");
        yield return new WaitForSeconds(12f/60f);
        SceneManager.LoadScene(number);

    }
}
