using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserGun : MonoBehaviour
{
    public Transform laserOrigin;
    public float gunRange = 50f;
    public float laserDuration = 0.05f;

    public GameObject player;
    public AudioSource shootSound;

    private LineRenderer laserLine;

    private void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        laserLine.SetPosition(0, laserOrigin.position);
    //        Vector3 rayOrigin = laserLine.transform.position;
    //        RaycastHit hit;
    //        if (Physics.Raycast(rayOrigin, player.transform.position - gameObject.transform.position, out hit, gunRange))
    //        {
    //            laserLine.SetPosition(1, hit.point);
    //            Destroy(hit.transform.gameObject);

    //        }
    //        else
    //        {
    //            laserLine.SetPosition(1, rayOrigin + (player.transform.position - gameObject.transform.position * gunRange));
    //        }
    //        StartCoroutine(ShootLazer());
    //    }
    //}

    public void TriggerShoot()
    {
        laserLine.SetPosition(0, laserOrigin.position);
        Vector3 rayOrigin = laserLine.transform.position;
        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, player.transform.position - gameObject.transform.position, out hit, gunRange))
        {
            laserLine.SetPosition(1, hit.point);
            if (hit.transform.gameObject.GetComponent<LifeManager>() != null)
            {
                hit.transform.gameObject.GetComponent<LifeManager>().Die();
                shootSound.Play();
            }

        }
        else
        {
            laserLine.SetPosition(1, rayOrigin + (player.transform.position - gameObject.transform.position * gunRange));
        }
        StartCoroutine(ShootLazer());
    }

    private IEnumerator ShootLazer()
    {
        laserLine.enabled = true;
        yield return new WaitForSeconds(1);
        laserLine.enabled = false;
    }





}
