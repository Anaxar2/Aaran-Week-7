using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public ColorPicker ColorPicker;

    public void NewColorSelected(Color color)
    { 
      GameManager.Instance.unitColor = color;   // add code here to handle when a color is selected
    }
    
    private void Start()
    {
        ColorPicker.Init();
        //this will call the NewColorSelected function when the color picker have a color button clicked.
        ColorPicker.onColorChanged += NewColorSelected;
        ColorPicker.SelectColor(GameManager.Instance.unitColor);
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
    GameManager.Instance.SaveColor();

#if UNITY_EDITOR
    EditorApplication.ExitPlaymode(); // quits play mode in unity editor.
#else
        Application.Quit(); // quits game but only in built games not editor (Unity).
#endif
    }
    public void SaveColorClicked()
    {
        GameManager.Instance.SaveColor();
    }
    public void LoadColorClicked()
    {
        GameManager.Instance.LoadColor();
        ColorPicker.SelectColor(GameManager.Instance.unitColor);
    }

}