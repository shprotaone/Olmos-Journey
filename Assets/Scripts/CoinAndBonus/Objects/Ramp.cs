using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    private AnimationController _controller;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            _controller = other.GetComponent<AnimationController>();
            Glide();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        StopGliding();
    }

    public void Glide()
    {
        _controller.Glide(true);
    }

    public void StopGliding()
    {
        _controller.Glide(false);
    }
}
