using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
public class Cutter : MonoBehaviour
{
    Transform cutPlane;
    public Material crossMaterial;

    void Start()
    {
        cutPlane = GetComponent<Transform>();
    }


    void Update()
    {
        cutPlane.eulerAngles += new Vector3(0, 0, -Input.GetAxis("Mouse X") * 5);

        //transform.localPosition = FindObjectOfType<Cursor>().point;

        if (Input.GetMouseButtonDown(0))
        {
            SliceSmth();
        }
    }

    public void SliceSmth()
    {
        Collider[] hits = Physics.OverlapBox(cutPlane.position, new Vector3(0.001f, 1f, 1f), cutPlane.rotation);

        if (hits.Length <= 0)
            return;

        for (int i = 0; i < hits.Length; i++)
        {
            SlicedHull hull = SliceObject(hits[i].gameObject, crossMaterial);
            if (hull != null)
            {
                GameObject bottom = hull.CreateLowerHull(hits[i].gameObject, crossMaterial);
                GameObject top = hull.CreateUpperHull(hits[i].gameObject, crossMaterial);
                AddHullComponents(bottom);
                AddHullComponents(top);
                top.GetComponent<MeshCollider>().enabled = false;
                bottom.GetComponent<MeshCollider>().enabled = false;

                Destroy(hits[i].gameObject);
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

        return obj.Slice(cutPlane.position, cutPlane.up, crossSectionMaterial);
    }
}
