using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem[] nodeParticles;
    public ParticleSystem[] endParticles;
    private NodeColourChange nodeChange;
    private bool nodeParticleFired = false;
    public bool isEnding = false;

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
        }
        yield return null;
    }

    public IEnumerator Ending()
    {
        foreach (ParticleSystem part in endParticles)
        {
            part.Play();
        }
        yield return null;
    }
}
