
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
    private int sceneToLoad = 1;



    public void NewColorSelected(Color color)
    {
        // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
    }

    
    // loads a new scene
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }


    // quits the application
    public void QuitApplication()
    {

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
