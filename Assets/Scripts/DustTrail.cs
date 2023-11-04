using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    [SerializeField] private ParticleSystem vfxDustTrail;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ParticleSystem.EmissionModule emissionModule = vfxDustTrail.emission;
            if (!vfxDustTrail.isEmitting)
            {
                emissionModule.enabled = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ParticleSystem.EmissionModule emissionModule = vfxDustTrail.emission;
            if (vfxDustTrail.isEmitting)
            {
                emissionModule.enabled = false;
            }
        }
    }
}
