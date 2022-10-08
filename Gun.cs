using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected Transform rifleStart;
    [SerializeField] protected GameObject bullet;
    //[SerializeField] protected Animator gunAnim;

    protected bool auto = false;
    protected float cooldown = 0;

    private float timer = 0;

    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0) || auto)
        {
            if (timer > cooldown)
            {
                OnShoot();
                //gunAnim.SetTrigger("");
                timer = 0;
            }
        }
    }

    protected virtual void OnShoot()
    {

    }
    private void Start()
    {
        timer = cooldown;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
}
