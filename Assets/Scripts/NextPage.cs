using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    [Range(0, 3)] public int currentOption = 0;

    [SerializeField] private GameObject[] pages;
    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private void Start()
    {
        // set the initial text of the button
        //setButtonText(currentOption);

        // add an event listener to look out for button clicks
        previousButton.onClick.AddListener(() => myButtonClick(currentOption--, false));
        nextButton.onClick.AddListener(() => myButtonClick(currentOption++, true));
    }

    private void Update()
    {
        // Minimum Value
        if (currentOption < 0)
        {
            currentOption = 0;
        }

        // Maximum Value
        if (currentOption > 3)
        {
            currentOption = 3;
        }
    }

    public void myButtonClick(int optionValue, bool isNext)
    {
        switch (currentOption)
        {
            case 0:
                if (isNext)
                {
                    DisplayNextPage(currentOption);
                }
                else
                {
                    DisplayPreviousPage(currentOption);
                }

                // change the text on the button to be the next option
                optionValue++;

                previousButton.gameObject.SetActive(false);
                return;

            case 2:
                if (isNext)
                {
                    DisplayNextPage(currentOption);
                }
                else
                {
                    DisplayPreviousPage(currentOption);
                }

                // change the text on the button to be the next option
                optionValue++;

                //setButtonText(currentOption);
                nextButton.gameObject.SetActive(false);
                return;

            
        }
        if (isNext)
        {
            DisplayNextPage(currentOption);
        }
        else
        {
            DisplayPreviousPage(currentOption);
        }
        previousButton.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);

    }

    public void DisplayNextPage(int currentOption)
    {
        pages[currentOption - 1].gameObject.SetActive(false);
        pages[currentOption].gameObject.SetActive(true);
    }

    public void DisplayPreviousPage(int currentOption)
    {
        pages[currentOption + 1].gameObject.SetActive(false);
        pages[currentOption].gameObject.SetActive(true);
    }
}
