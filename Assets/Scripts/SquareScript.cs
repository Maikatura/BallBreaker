using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareScript : MonoBehaviour
{
    public GameObject particle;

    private ParticleSystem parts;
    public AudioClip hitEffect;
    [Range(0f, 1f)]
    public float clipVolume;


    public void OnHitEffect()
    {  
        MapEditor.instance.PlaySound(hitEffect, clipVolume);
        parts = Instantiate(particle, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
        float total = parts.duration + parts.startLifetime;
        parts.Play();
        Destroy(parts.gameObject, total);
    }

    public virtual void DestroySelf()
    {
        //cool on death effects
        OnHitEffect();

        MapEditor.instance.DestroyTile(this.transform.position);
    }
}
