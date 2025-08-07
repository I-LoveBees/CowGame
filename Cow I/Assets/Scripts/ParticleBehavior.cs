using UnityEngine;
using UnityEngine.Events;

public class ParticleBehavior : MonoBehaviour
{
    public UnityEvent onParticleCollisionEvent;

    private void OnParticleCollision(GameObject other)
    {
        onParticleCollisionEvent.Invoke();
    }
}