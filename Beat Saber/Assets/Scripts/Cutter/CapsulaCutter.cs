using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;

public class CapsulaCutter : MonoBehaviour
{
    [SerializeField] GameObject sparks;
    Transform cutCapsule;
    
    public Material crossMaterial;

    void Start()
    {
        cutCapsule = GetComponent<Transform>();
    }


    void Update()
    {
        SliceSmth();
    }

    public void SliceSmth()
    {
        Collider[] hits = Physics.OverlapBox(cutCapsule.position, new Vector3(0.05f, 0.5f, 0.2f), cutCapsule.rotation);


        if (hits.Length <= 0)
            return;

        for (int i = 0; i < hits.Length; i++)
        {
            SlicedHull hull = SliceObject(hits[i].gameObject, crossMaterial);
            if (hull != null)
            {
                if (hits[i].gameObject.GetComponent<Cube>() == null)
                    return;
                GameObject bottom = hull.CreateLowerHull(hits[i].gameObject, crossMaterial);
                GameObject top = hull.CreateUpperHull(hits[i].gameObject, crossMaterial);
                AddHullComponents(bottom);
                AddHullComponents(top);

                top.GetComponent<MeshCollider>().enabled = false;
                bottom.GetComponent<MeshCollider>().enabled = false;

                Vector3 cubePosition = hits[i].gameObject.transform.position;

                print(Input.mousePosition);
                FindObjectOfType<ComboCounter>().counter++;
                FindObjectOfType<Accuracy>().totalHitCounter++;
                FindObjectOfType<Score>().AddPoints();

                GameObject sparksInstance = Instantiate(sparks, new Vector3(cubePosition.x, cubePosition.y * 0.5f, cubePosition.z), Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
                
                var main = sparksInstance.GetComponent<ParticleSystem>().main;
                main.startColor = hits[i].gameObject.GetComponent<Cube>().color;

                Destroy(sparksInstance, 1f);
                Destroy(hits[i].gameObject);

                Destroy(bottom, 2f);
                Destroy(top, 2f);

            }
        }
    }

    public void AddHullComponents(GameObject go)
    {
        go.layer = 9;
        Rigidbody rb = go.AddComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        MeshCollider collider = go.AddComponent<MeshCollider>();
        collider.convex = true;

        rb.AddExplosionForce(100, go.transform.position, 20);
    }

    public SlicedHull SliceObject(GameObject obj, Material crossSectionMaterial = null)
    {
        // slice the provided object using the transforms of this object
        if (obj.GetComponent<MeshFilter>() == null)
            return null;

        return obj.Slice(cutCapsule.position, cutCapsule.right, crossSectionMaterial);
    }
}
