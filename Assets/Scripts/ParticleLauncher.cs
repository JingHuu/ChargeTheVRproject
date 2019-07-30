using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{
    public ParticleSystem[] nodeParticles;
    private NodeColourChange nodeChange;
    private bool particleFired = false;

    private void Start()
    {
        nodeChange = GetComponentInChildren<NodeColourChange>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nodeChange.hasFired)
        {
            if (!particleFired)
            {
                StartCoroutine(NodeInPlace());
                particleFired = true;
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
}
