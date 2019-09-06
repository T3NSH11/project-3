using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item that when used while held acts as a physics based projectile instantiator
/// </summary>
public class NerfGunItem : InteractiveItem
{
    public GameObject nerfDartPrefab;
    public Transform nerfDartSpawnLocation;
    public float fireRate = 1;
    public float launchForce = 10;
    protected float fireRateCounter;
    protected void Update()
    {
        fireRateCounter += Time.deltaTime;
    }

    public override void OnUse()
    {
        base.OnUse();
        if (isHeld)
        {
            if (fireRateCounter > fireRate)
            {
                fireRateCounter = 0;
                FireNow();
            }
        }
        //TODO: we need to determine if we can fire and if so, make the thing
    }

    public void FireNow()
    {
        var newdart = Instantiate(nerfDartPrefab, nerfDartSpawnLocation.position, nerfDartSpawnLocation.rotation);
        var newDartRB = newdart.GetComponent<Rigidbody>();
        if(newDartRB != null)
        {
            newDartRB.AddForce(launchForce * transform.forward);
        }
        //TODO: this is where we would actually create the thing and get it on its way
    }
}
