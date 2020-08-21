using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject enemy;
    public int PortalNumber;
    public GameObject TransitionPanel;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (enemy==null)
        {
            if (col.tag == "Player")
            {
                Time.timeScale = 1;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Physics2D.gravity = new Vector2(0, -30);
                player.fallMultiplier = 2.2f;
                player.StartDashTime = 0.2f;
                player.NormalWeapon.SetActive(true);
                player.SpiritWeapon.SetActive(false);
                player.anim.runtimeAnimatorController = player.NormalAnim as RuntimeAnimatorController;
                player.InvincibleOff();
                TransitionPanel.GetComponent<Trans>().LoadScene(PortalNumber);
                //SceneManager.LoadScene(PortalNumber);
            }
        }
    }
}
