using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Talkable : MonoBehaviour
{
    public Flowchart TalkableFlowChart;
    public string str;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "PlayerHitBox")
        {
            Block block = TalkableFlowChart.FindBlock(str);
            TalkableFlowChart.ExecuteBlock(block);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "PlayerHitBox")
        {
            Destroy(gameObject);
        }
    }

}
