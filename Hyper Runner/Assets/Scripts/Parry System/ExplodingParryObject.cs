using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Parry object that explodes upon jumping on to it
/// </summary>
public class ExplodingParryObject : AParryObject {
    [Header("Required for ExplodingParryObject")]
    [SerializeField] private GameObject particles; // particles to spawn once parried
    
    public override void OnParry()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Instantiate(this.particles, pos, Quaternion.identity);
        Destroy((this.gameObject));
    }
}