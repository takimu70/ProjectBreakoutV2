using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject bridge0;
    [SerializeField] private GameObject bridge90;
    [SerializeField] private GameObject bridge180;
    [SerializeField] private GameObject bridge270;

    public void Activate0()
    {
        bridge0.SetActive(true);
        bridge90.SetActive(false);
        bridge180.SetActive(false);
        bridge270.SetActive(false);
    }

    public void Activate90()
    {
        bridge0.SetActive(false);
        bridge90.SetActive(true);
        bridge180.SetActive(false);
        bridge270.SetActive(false);

    }

    public void Activate180()
    {
        bridge0.SetActive(false);
        bridge90.SetActive(false);
        bridge180.SetActive(true);
        bridge270.SetActive(false);

    }

    public void Activate270()
    {
        bridge0.SetActive(false);
        bridge90.SetActive(false);
        bridge180.SetActive(false);
        bridge270.SetActive(true);

    }

}



