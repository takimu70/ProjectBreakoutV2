using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class boxTrigger_Script : MonoBehaviour
{
    public GameObject computerScreenUI;

    private bool isInRange = false;
    public int floppyId;
    public bool needsFloppy = false;
    public bool hasFloppy;

    private void Awake()
    {
        Floppy.onFloppyPickedUp += HasFloppy;
    }

    public void HasFloppy(int id)
    {
        if (id == floppyId)
        {
            hasFloppy = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
        if (!needsFloppy)
        {
            TextManager.instance.NotifyPlayer("Press 'E' to interact.");
        }else if (needsFloppy && !hasFloppy)
        {
            TextManager.instance.NotifyPlayer("Need floppy disk.");
        }


    }

    public UnityEvent response;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            computerScreenUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        TextManager.instance.CloseText();
    }

    private void Update()
    {
        if (needsFloppy == false)
        {

            if (isInRange && Input.GetKeyDown(KeyCode.E) && !computerScreenUI.gameObject.active)
            {
                computerScreenUI.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                response.Invoke();
            }
            else if (isInRange && Input.GetKeyDown(KeyCode.Escape))
            {
                computerScreenUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
        if (needsFloppy == true)
        {
            if (hasFloppy == true)
            {
                if (isInRange && Input.GetKeyDown(KeyCode.E) && !computerScreenUI.gameObject.active)
                {
                    computerScreenUI.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    response.Invoke();
                }
                else if (isInRange && Input.GetKeyDown(KeyCode.Escape))
                {
                    computerScreenUI.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }


            }
        }

    }




}