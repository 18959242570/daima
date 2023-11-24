using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class answer : MonoBehaviour
{
    private GameObject photo;
    private GameObject photo1;
    AudioSource m_AudioSource;
    public Transform truepoint;
    private bool canplaysound = true;
    public float enemydeadtime;
    public GameObject enemyDied;
    public GameObject zimo;
    public bool caneat = false;

    // Start is called before the first frame update
    void Start()
    {
        photo = GetComponent<GameObject>();
        m_AudioSource = GetComponent<AudioSource>();
        truepoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player")&&Input.GetKey(KeyCode.V))
        {
            photo =GameObject.Find("PictureFrame_Curvy");
            photo.transform.position = truepoint.position;
            photo.transform.rotation = Quaternion.Euler(0, 45, 0);
            
        }
        photo = GameObject.Find("PictureFrame_Curvy");

        if (truepoint.position == photo.transform.position && canplaysound == true)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
                canplaysound = false;
            }
            Destroy(photo, enemydeadtime);


            Destroy(gameObject, enemydeadtime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.V))
        {
            photo = GameObject.Find("PictureFrame_Curvy");
            photo.transform.position = truepoint.position;
            photo.transform.rotation = Quaternion.Euler(0, 180, 0);
            
        }
    }
    public void OnDestroy()
    {
        Instantiate(enemyDied,transform.position,Quaternion.identity);
        zimo.active = true;
        caneat = true;
    }
}
