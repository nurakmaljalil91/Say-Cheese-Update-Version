using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombParticle : MonoBehaviour
{
    public AudioClip explosionSound;
    // Start is called before the first frame update
    void Start()
    {
        AudioController.Instance.PlayBombAudio();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("_Delete", 3);
    }

    private void _Delete()
    {
        Destroy(this.gameObject);
    }
}
