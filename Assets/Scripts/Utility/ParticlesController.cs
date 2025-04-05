using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particlesOnDestroyPrefab; 
    private static bool _isQuitting = false;

    private void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    private void OnDestroy()
    {
        if (_isQuitting)
            return;

        if (_particlesOnDestroyPrefab != null)
            PlayParticlesOnDestroy();
    }

    private void PlayParticlesOnDestroy()
    {
        ParticleSystem destroyEffect = Instantiate(_particlesOnDestroyPrefab, transform.position, Quaternion.identity);
        destroyEffect.Play();

        Destroy(destroyEffect.gameObject, destroyEffect.main.startLifetime.constantMax);
    }

}
