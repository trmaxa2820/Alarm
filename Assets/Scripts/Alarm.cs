using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private bool _isAlarmed = false;
    private GameObject _door;
    
    void Start()
    {
        _door = gameObject.GetComponent<GameObject>();
        _audioSource.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isAlarmed == true)
        {
            _audioSource.volume += Time.deltaTime;
            if(_audioSource.volume >= 1)
            {
                _audioSource.volume = 1f;
            } 
        }
        else
        {
            _audioSource.volume -= Time.deltaTime;
            if(_audioSource.volume <= 0)
            {
                _audioSource.volume = 0;
                _audioSource.Stop();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            if (_isAlarmed == false) 
            {
                _isAlarmed = true;
                _audioSource.Play();
            }
            else if (_isAlarmed == true)
            {
                _isAlarmed = false;
            }
        }
    }
}
