using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem[] nodeParticles;
    public ParticleSystem[] endParticlesImplode;
    public ParticleSystem[] endParticlesExplode;
    public float delay;
    private NodeColourChange nodeChange;
    private bool nodeParticleFired = false;
    [HideInInspector] public bool isEnding = false;
    private bool alreadyEnd = false;
    
    private void Start()
    {
        nodeChange = GetComponentInChildren<NodeColourChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nodeChange.hasFired)
        {
            if (isEnding)
            {
                if(!alreadyEnd)
                StartCoroutine(Ending());
            }
            else if (!nodeParticleFired)
            {
                StartCoroutine(NodeInPlace());
                nodeParticleFired = true;
            }
        }
    }

    public IEnumerator NodeInPlace()
    {
        foreach (ParticleSystem part in nodeParticles)
        {
            part.Play();
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/SFX/NodeInPlace", this.gameObject);
        }
        yield return null;
    }

    public IEnumerator Ending()
    {
        foreach (ParticleSystem part in endParticlesImplode)
        {
            alreadyEnd = true;
            part.Play();
        }
        yield return new WaitForSeconds(delay);

        foreach (ParticleSystem part in endParticlesExplode)
        {
            part.Play();
        }
    }
}
