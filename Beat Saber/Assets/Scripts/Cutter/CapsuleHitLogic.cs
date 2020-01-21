using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class CapsuleHitLogic : MonoBehaviour
{
    [SerializeField] GameObject sparks;

    Transform capsuleTransform;

    void Start()
    {
        capsuleTransform = GetComponent<Transform>();
    }

    void Update()
    {
        HitCube();
    }

    private void HitCube()
    {
        Collider[] hits = Physics.OverlapBox(capsuleTransform.position, new Vector3(0.05f, 0.5f, 0.2f), capsuleTransform.rotation);

        if (hits.Length <= 0)
            return;

        for (int i = 0; i < hits.Length; i++)
        {
            Vector3 cubePosition = hits[i].gameObject.transform.position;
            
            FindObjectOfType<ComboCounter>().counter++;
            FindObjectOfType<Accuracy>().totalHitCounter++;
            FindObjectOfType<Score>().AddPoints();

            GameObject sparksInstance = Instantiate(sparks, new Vector3(cubePosition.x, cubePosition.y * 0.5f, cubePosition.z), Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            
            var main = sparksInstance.GetComponent<ParticleSystem>().main;
            main.startColor = hits[i].gameObject.GetComponent<Cube>().color;

            Destroy(sparksInstance, 1f);
            Destroy(hits[i].gameObject);

        }
    }
}
