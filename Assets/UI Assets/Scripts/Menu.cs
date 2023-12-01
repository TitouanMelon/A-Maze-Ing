using System;
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
        _createDataFile();

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

            string[] score = _loadScore();
            int number = 0;
            foreach (GameObject line in scoreLine)
            {
                line.SetActive(false);
                if (score != null)
                {
                    TextMeshProUGUI[] texts = {};
                    texts = line.GetComponentsInChildren<TextMeshProUGUI>();        
                    foreach(TextMeshProUGUI text in texts)
                    {
                        if (number < score.Length)
                        {
                            line.SetActive(true);
                            if (text.name.Equals("player"))
                                text.text = score[number].Split(':')[0];
                            else if (text.name.Equals("score"))
                            {
                                int t = (int)float.Parse(score[number].Split(':')[1]);
                                text.text = (((int)t)/60).ToString("00") + ":" + (((int)t)%60).ToString("00");
                            }
                        }
                    }
                    number++;
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

    private string[] _loadScore()
    {
        TextReader reader;
        string fileName = Application.persistentDataPath + "/Score/"+index.ToString()+".txt";
        string readLine = "";
        List<string> scoreList = new List<string>();

        reader = new StreamReader(fileName);

        //Get all score
        while (true)
        {
            readLine = reader.ReadLine();
            if (readLine==null) break;
            scoreList.Add(readLine);
        }
        reader.Close();

        if (scoreList.Count == 0)
            return null;

        List<float> scoreTimeList = new List<float>();
        foreach (string l in scoreList)
        {
            scoreTimeList.Add(float.Parse(l.Split(':')[1]));
        }

        string[] score = scoreList.ToArray();
        float[] scoreTime = scoreTimeList.ToArray();

        int offset = 0;
        int line = offset;
        while (true)
        {
            line = offset;
            for (int i=offset ; i<scoreTime.Length ; i++)
            {
                if (scoreTime[line] < scoreTime[i])
                    line = i;
            }

            string tmpString = score[offset];
            float tmpFloat = scoreTime[offset];

            score[offset] = score[line];
            scoreTime[offset] = scoreTime[line];
            
            score[line] = tmpString;
            scoreTime[line] = tmpFloat;

            offset++;
            if (offset == score.Length)
                break;
        }

        Array.Reverse(score);
        return score;
    }

    private void _createDataFile()
    {
        if(!Directory.Exists(Application.persistentDataPath+"/Score"))
            Directory.CreateDirectory(Application.persistentDataPath+"/Score");
        
        for (int i=1 ; i<13 ; i++)
        {
            if (!File.Exists(Application.persistentDataPath+"/Score/"+i.ToString()+".txt"))
                File.WriteAllText(Application.persistentDataPath+"/Score/"+i.ToString()+".txt", "");
        }
    }
}
