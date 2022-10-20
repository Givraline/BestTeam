using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    [Range(0, 3)] public int currentOption = 0;

    [SerializeField] private Button previousButton;
    [SerializeField] private Button nextButton;

    private void Start()
    {
        // set the initial text of the button
        //setButtonText(currentOption);

        // add an event listener to look out for button clicks
        previousButton.onClick.AddListener(() => myButtonClick(currentOption--));
        nextButton.onClick.AddListener(() => myButtonClick(currentOption++));
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

    public void myButtonClick(int optionValue)
    {
        switch (currentOption)
        {
            case 0:
                // run stuff for option 1
                RunCode0();

                // change the text on the button to be the next option
                optionValue++;

                //setButtonText(currentOption);
                break;

            case 1:
                Debug.Log("Doing option 2 things");
                RunCode1();

                // change the text on the button to be the next option
                optionValue++;

                //setButtonText(currentOption);
                break;

            case 2:
                Debug.Log("Doing option 3 things");
                RunCode2();

                // change the text on the button to be the next option
                optionValue++;

                //setButtonText(currentOption);
                break;

            case 3:
                Debug.Log("Doing option 4 things");
                RunCode3();

                // change the text on the button to be the next option
                optionValue++;

                //setButtonText(currentOption);
                break;
        }

    }

    public void RunCode0()
    {
        //Do something
    }

    public void RunCode1()
    {
        //Do something
    }

    public void RunCode2()
    {
        //Do something
    }

    public void RunCode3()
    {
        //Do something
    }
}
