
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// enable scene management
using UnityEngine.SceneManagement;


// allows the application to quit if we are using the usnity editor
#if UNITY_EDITOR

using UnityEditor;

#endif



// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;


    // reference to 'main' scene
    private int mainScene = 1;




    private void Start()
    {
        ColorPicker.Init();

        // this will call the NewColorSelected function when the color picker has a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;


        // when the menu scene loads
        // load the selected colour
        ColorPicker.SelectColor(MainManager.Instance.unitColour);
    }


    public void NewColorSelected(Color color)
    {
        MainManager.Instance.unitColour = color;

        // add code here to handle when a color is selected
    }

    
    // loads a new scene
    public void LoadScene()
    {
        SceneManager.LoadScene(mainScene);
    }


    // save the selected colour
    public void SaveSelectedColour()
    {
        MainManager.Instance.SaveColour();
    }


    // load the selected colour
    public void LoadSelectedColour()
    {
        MainManager.Instance.LoadColour();

        ColorPicker.SelectColor(MainManager.Instance.unitColour);
    }



    // quits the application
    public void QuitApplication()
    {
        // save the last selected colour
        MainManager.Instance.SaveColour();



// if we are using the unity editor
#if UNITY_EDITOR

        // quit the application from the editor
        EditorApplication.ExitPlaymode();

// otherwise
#else

        // quit the application as normal
        Application.Quit();

#endif

    }


} // end of class
