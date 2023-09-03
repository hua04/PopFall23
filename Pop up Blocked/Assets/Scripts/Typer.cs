using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Typer : MonoBehaviour
{
    public TextMeshProUGUI wordOutput;
    public TextMeshProUGUI timer;
    public GameObject spawner;
    PopUpSpawner popUpSpawner;

    private string remainingWord;
    private string typedWord;
    private string currentWord = "I'm sorry that I hurt you.";
    public float timeRemaining = 60;

    void Start()
    {
        SetCurrentWord();
        spawner = GameObject.Find("PopUpSpawner"); //Gets spawner so we can check if popups are on screen
        popUpSpawner = spawner.GetComponent<PopUpSpawner>();
        
    }

    void SetCurrentWord()
    {
        SetRemainingWord(currentWord);
    }

    void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<b>" + typedWord + "</b>" + "<color=#40484a>" + remainingWord + "</color>";//Creates color difference between word already typed and not yet typed
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        if (timeRemaining > 0) //counts down and desplays timer
        {
            timeRemaining -= (Time.deltaTime);
            float seconds = Mathf.FloorToInt(timeRemaining);
            timer.text = seconds.ToString();
        }
        else if(timeRemaining <= 0 && !IsComplete()) //Run out of time
        {
            Debug.Log("Failed");
            //TODO: Program switch to failure screen
        }

    }


    void CheckInput()
    {
        if (popUpSpawner.currentPopups == 0) //Only allows typing when no pop ups are on screen
        {
            if (Input.anyKeyDown)
            {
                string keysPressed = Input.inputString;
                if (keysPressed.Length == 1)
                {
                    EnterLetter(keysPressed); //detects letter press
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

            if (IsComplete()) //checks if player has completed the typed sentances
            {
                Debug.Log("Done");
                //TODO: Add win screen

            }
        }

    }
    bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0; //checks if letter is correct
    }
    void RemoveLetter()
    {
        char temp = remainingWord[0];
        string newString = remainingWord.Remove(0, 1);
        typedWord += temp;
        SetRemainingWord(newString);
    }

    bool IsComplete()
    {
        return remainingWord.Length == 0;
    }
}
