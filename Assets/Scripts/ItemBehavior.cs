using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior gameManager;


    // Start is called before the first frame update
      void Start()
      {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
      }  
    void OnCollisionEnter(Collision collision)
    {
        bool val;
        if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.parent.gameObject);
            Debug.Log("Item collected!");

            gameManager.Items += 1;
            // Debug.LogFormat("Items: {0}", gameManager.Items);
            gameManager.PrintLootReport();
             
            if(gameManager.Items == 4)
            {
                val = true;
                gameManager.PrintLootReport(val);
            }
            else
            {
                val = false;
                gameManager.PrintLootReport(val);
            }
        }
    }
  //
  //  // Update is called once per frame
  //  void Update()
  //  {
  //      
  //  }
}
