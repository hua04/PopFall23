using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Typer : MonoBehaviour
{
    public TextMeshProUGUI wordOutput;
    public GameObject spawner;
    PopUpSpawner popUpSpawner;

    private string remainingWord;
    private string currentWord= "I'm sorry that I hurt you.";

    // Start is called before the first frame update
    void Start()
    {
        SetCurrentWord();
        spawner = GameObject.Find("PopUpSpawner");
        popUpSpawner = spawner.GetComponent<PopUpSpawner>();
    }

    void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord=newString;
        wordOutput.text = remainingWord;
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (popUpSpawner.currentPopups == 0)
        {
            if (Input.anyKeyDown)
            {
                string keysPressed = Input.inputString;
                if (keysPressed.Length == 1)
                {
                    EnterLetter(keysPressed);
                }
            }
        }
        else
        {
            Debug.Log("popup active");
        }
       

    }

    void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

            if (IsComplete())
            {
                Debug.Log("Done");
            }
        }

    }
    bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter)==0;
    }
    void RemoveLetter()
    {
        string newString = remainingWord.Remove(0,1);
        SetRemainingWord(newString);
    }

    bool IsComplete()
    {
        return remainingWord.Length==0;
    }
}
