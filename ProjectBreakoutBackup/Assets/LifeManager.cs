using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class LifeManager : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private Animator anim;

    public bool isDead = false;
    public float respawnTime;
    public Transform respawnPos;

    private Rigidbody rb;

    public int floppyAmount;
    private void Start()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        anim = GetComponent<Animator>();
        //rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            this.gameObject.transform.position = transform.position;
            Debug.Log("falling");
        }  
    }


    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            anim.Play("Electrocuted");
            Invoke("RespawnInSeconds", respawnTime);
        }
    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Floppy>() != null)
        {
            other.GetComponent<Floppy>().InvokeFloppyEvent();
        }
    }

    private void RespawnInSeconds()
    {
        //rb.position = respawnPos.position;
        transform.position = respawnPos.position; // Move player to respawn location
        isDead = false;

        anim.SetTrigger("TrRespawn");
    }

}
