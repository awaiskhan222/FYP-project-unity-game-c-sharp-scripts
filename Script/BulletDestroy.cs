using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] float timetodestroy;
    float timer;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timetodestroy)
        {
            Destroy(this.gameObject);

        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "gun") Destroy(this.gameObject);

    }
}
