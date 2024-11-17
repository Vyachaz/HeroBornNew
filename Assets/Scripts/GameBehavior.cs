using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CustomExtensions;
using System.Collections.Generic;

public class GameBehavior : MonoBehaviour, IManager
{
    public string lableText = "Collect all 4 items and win your freedom!";
    public int maxItems = 4;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public Stack<string> lootStack = new Stack<string>();

    private int _itemsCollected = 0;
    private string _state;

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }
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


    private int _playerHP = 3;
    public int HP
    {
        get
        {
            return _playerHP;
        }

        set
        {
            _playerHP = value;
           //Debug.LogFormat("Items: {0}", _playerHP);
           if(_playerHP <= 0)
            {
                lableText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0f;
            }
            else
            {
                lableText = "Ouch... that's got hurt.";
            }
        }
    }

   // private void RestartLevel()
   // {
   //     SceneManager.LoadScene(0);
   //     Time.timeScale = 1.0f;
   // }

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
               // RestartLevel();
               Utilities.RestartLevel();

            }
        }
        if (showLossScreen)
        { 
            if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100),"You lose..."))
            {
                // RestartLevel();
                Utilities.RestartLevel(0);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initialize()
    {
        _state = "Manager initialaized...";
        _state.FancyDebug();
        Debug.Log(_state);

        lootStack.Push("Sword of Doom");
        lootStack.Push("HP++");
        lootStack.Push("Golden Key");
        lootStack.Push("Winget Boot");
        lootStack.Push("Mithril Bracers");

    }
    public void PrintLootReport()
    {
        var currentItem = lootStack.Pop();
        var nextItem = lootStack.Peek();


        Debug.LogFormat("You goy a {0}!!! You've got a good chance of findidng a {1} next!!!", currentItem, nextItem);
        Debug.LogFormat("There are {0} random loot items waiting for you!!", lootStack.Count);
    }
    public void PrintLootReport(bool val)
    {
        if (!val)
        {
            string strStack = lootStack.ToString();
            Debug.Log($"Stack = {strStack}");
        }
        else
        {
            Debug.Log($" Last element of Stack = {lootStack.Peek()}");

        }
    }
}
