using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteExplosionParticles : MonoBehaviour
{
    void Start()
    {
        Destroy(this.gameObject, 1.1f);
    }
}
