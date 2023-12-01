using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; 
using System.Text;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject backgroundObj = null;
    public GameObject mainMenuObj = null;
    public GameObject levelMenuObj = null;
    public GameObject scoreMenuObj = null;

    //scoreMenu
    public Button nextButton = null;
    public Button lastButton = null;
    public Button[] exitButton = {};
    public TextMeshProUGUI levelName = null;

    public GameObject[] scoreLine = {};
    private TextMeshProUGUI player = null;
    private TextMeshProUGUI score = null;
    private int index = 1;
    private bool reload = true;

    //levelMenu
    public GameObject levelButtons = null;


    void Start()
    {
        backgroundObj.SetActive(true);
        mainMenuObj.SetActive(true);
        levelMenuObj.SetActive(false);
        scoreMenuObj.SetActive(false);

        //scoreMenu
        if (nextButton != null)
	        nextButton.onClick.AddListener(_onNext);
        if (lastButton != null)
	        lastButton.onClick.AddListener(_onLast);
        foreach (Button btn in exitButton)
	        btn.onClick.AddListener(_onExit);

        //levelMenu
        foreach(Button btn in levelButtons.GetComponentsInChildren<Button>())
        {
            string level = btn.name.Split('_')[1];
            btn.onClick.AddListener(delegate{_loadLevel(level);});
        }
    }

    void Update()
    {
        if (reload)
        {
            reload = false;
            levelName.text = "Level " + index.ToString();

            TextReader reader;
            string fileName = "./Assets/Score/"+index.ToString()+".txt";
            reader = new StreamReader(fileName);
            string result = reader.ReadToEnd();
            reader.Close();

            int number = 0;
            foreach (GameObject line in scoreLine)
            {
                line.SetActive(false);
                int i = int.Parse(line.name.Split('_')[1]);
                TextMeshProUGUI[] texts = {};
                texts = line.GetComponentsInChildren<TextMeshProUGUI>();
                foreach(TextMeshProUGUI text in texts)
                {
                    if (number < (result.Split('\n').Length)-1)
                    {
                        line.SetActive(true);
                        if (text.name.Equals("player"))
                            text.text = result.Split('\n')[number].Split(':')[0];
                        else if (text.name.Equals("score"))
                            text.text = result.Split('\n')[number].Split(':')[1];
                        number++;
                    }
                }
            }
        }
    }

    private void _onNext()
    {
        reload = true;
        index++;
        if (index == 13)
            index = 1;
    }

    private void _onLast()
    {
        reload = true;
        index--;
        if (index  == 0)
            index = 12;
    }

    private void _onExit()
    {
        backgroundObj.SetActive(true);
        mainMenuObj.SetActive(true);
        levelMenuObj.SetActive(false);
        scoreMenuObj.SetActive(false);
    }
    private void _loadLevel(string level)
    {
        backgroundObj.SetActive(true);
        mainMenuObj.SetActive(true);
        levelMenuObj.SetActive(false);
        scoreMenuObj.SetActive(false);
        SceneManager.LoadScene("Level_"+level);
    }
}
