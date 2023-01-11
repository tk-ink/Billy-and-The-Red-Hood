using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public GameObject settingsMenu;

    private bool settingsOpen = false;

    public static Action shootInput;


    void Start()
    {
        settingsMenu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootInput?.Invoke();
        }


        if (Input.GetKeyDown(KeyCode.Escape) && !settingsOpen)
        {
            openSettings();
        }else if (Input.GetKeyDown(KeyCode.Escape) && settingsOpen)
        {
            closeSettings();
        }
    }

    public void openSettings()
    {
        settingsOpen = true;
        settingsMenu.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void closeSettings()
    {
        settingsOpen = false;
        settingsMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }





}
