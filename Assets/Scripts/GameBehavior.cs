using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    public string lableText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;

    private int _itemsCollected = 0;

    public int Items
    {
        get
        {
            return _itemsCollected;
        }

        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);

            if (_itemsCollected >= maxItems)
            {
                lableText = "You've found all the items!";
                showWinScreen = true;
                Time.timeScale = 0f;
            }
            else { 
                lableText = "Item found? only " + (maxItems - _itemsCollected) +
                    " more to go!";
            }
        }

    }


    private int _playerHP = 10;
    public int HP
    {
        get
        {
            return _playerHP;
        }

        set
        {
            _playerHP = value;
            Debug.LogFormat("Items: {0}", _playerHP);
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " + _playerHP);

        GUI.Box(new Rect(20, 50, 150, 25), "Items Collected: " + _itemsCollected );

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300,50),
            lableText);

        if (showWinScreen) 
        {
            if(GUI.Button(new Rect(Screen.width/2 -100, Screen.height/2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene(0);
                Time.timeScale = 1.0f;

            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
