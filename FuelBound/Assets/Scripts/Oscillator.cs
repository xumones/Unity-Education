using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; } //Epsilon is the smaller number in decimal near 0 the most 
        const float tau = Mathf.PI * 2; // 2pi = 1tau that mean 1tau equal 6.28~~~
        float cycles = Time.time / period; // timer that will alway devind with period(which mean bigger period equal bigger amount of time we want)
        float rawSinWave = Mathf.Sin(cycles * tau); // because tae = 1circle then when the cycle count by 1 equal 1 circle multiply by tae ex.1 circle * 1 tau(6.28~~) == 6.28(1circle)

        movementFactor = (rawSinWave +1f) / 2; //we make it look like this because we don't want a value between -1 to 1 but we want the changing position that make object move
        // EX. -1 + 1 = 0 / 2 -> 0 or 1 + 1 = 2/2 = 1 because we want the object move in update that code will alway execute so we need it to change by 1 (but can change it by period)
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPosition + offset;
    }
}
