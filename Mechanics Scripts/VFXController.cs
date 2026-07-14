using System.Collections;
using UnityEngine;

public class VFXController : MonoBehaviour
{
    [Header ("Environmental VFX")]
    [SerializeField] ParticleSystem envParticle;

    void Start()
    {
        //StartCoroutine(StopEmmiting());
    }

    void Update()
    {
        if(UIManager.Instance.gameState != UIManager.GameState.Neutral)
            envParticle.Pause();
        else
            envParticle.Play();
    }

    IEnumerator StopEmmiting()
    {
        yield return new WaitUntil(() => UIManager.Instance.gameState == UIManager.GameState.Neutral);
        
    }
}
