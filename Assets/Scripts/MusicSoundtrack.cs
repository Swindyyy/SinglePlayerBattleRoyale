using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSoundtrack : MonoBehaviour {

    #region singleton
    public static MusicSoundtrack instance;

    void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
            return;
        }

        instance = null;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
