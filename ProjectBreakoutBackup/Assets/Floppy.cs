using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floppy : MonoBehaviour
{
    public int floppyId;

    public delegate void FloppyPickedUp(int floppyId);
    public static event FloppyPickedUp onFloppyPickedUp;

    public void InvokeFloppyEvent()
    {
        onFloppyPickedUp.Invoke(floppyId);
        Destroy(this.gameObject);
    }


}
