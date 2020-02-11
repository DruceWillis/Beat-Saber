using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BzKovSoft.ObjectSlicer;
using System.Diagnostics;

namespace BzKovSoft.ObjectSlicerSamples
{
	/// <summary>
	/// This script will invoke slice method of IBzSliceableNoRepeat interface if knife slices this GameObject.
	/// The script must be attached to a GameObject that have rigidbody on it and
	/// IBzSliceable implementation in one of its parent.
	/// </summary>
	[DisallowMultipleComponent]
	public class KnifeSliceableAsync : MonoBehaviour
	{
    	
		[SerializeField] GameObject sparks;
		IBzSliceableNoRepeat _sliceableAsync;
		
		void Start()
		{
			_sliceableAsync = GetComponentInParent<IBzSliceableNoRepeat>();
		}

		void OnTriggerEnter(Collider other)
		{
			var knife = other.gameObject.GetComponent<BzKnife>();
			if (knife == null)
				return;

			Rigidbody rigidbody = this.gameObject.GetComponent<Rigidbody>();

			rigidbody.useGravity = true;

			
			
			StartCoroutine(Slice(knife));
			StartCoroutine(AddForceInOppositeDirection(knife));

		}

		private IEnumerator AddForceInOppositeDirection(BzKnife knife)
		{
			
			yield return new WaitForSeconds(0.05f);
			
			this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3 (knife.MoveDirection.x*4, knife.MoveDirection.y*4, -3f), ForceMode.Impulse);
			
			Destroy(this.gameObject, 1f);
			

		}

		private IEnumerator Slice(BzKnife knife)
		{
			// The call from OnTriggerEnter, so some object positions are wrong.
			// We have to wait for next frame to work with correct values
			yield return null;

			Vector3 point = GetCollisionPoint(knife);
			Vector3 normal = Vector3.Cross(knife.MoveDirection, knife.BladeDirection);
			Plane plane = new Plane(normal, point);

			if (this.gameObject.GetComponent<MeshCollider>() == null && this.gameObject.GetComponent<BoxCollider>() != null)
			{
				FindObjectOfType<ComboCounter>().counter++;
				FindObjectOfType<Accuracy>().totalHitCounter++;
				FindObjectOfType<Score>().AddPoints();
				GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
			}

			if (_sliceableAsync != null)
			{
				_sliceableAsync.Slice(plane, knife.SliceID, null);
			}
			
			Vector3 cubePosition = this.gameObject.transform.position;
			
			GameObject sparksInstance = Instantiate(sparks, new Vector3(cubePosition.x, cubePosition.y * 0.5f, cubePosition.z), Quaternion.identity);
                
			var main = sparksInstance.GetComponent<ParticleSystem>().main;
			main.startColor = this.gameObject.GetComponent<Cube>().color;
			

			if (this.gameObject.GetComponent<MeshCollider>() != null)
				this.gameObject.GetComponent<MeshCollider>().enabled = false;

			if (this.gameObject.GetComponent<BoxCollider>() != null)
				this.gameObject.GetComponent<BoxCollider>().enabled = false;

			Destroy(sparksInstance, 1f);
		}

		private Vector3 GetCollisionPoint(BzKnife knife)
		{
			Vector3 distToObject = transform.position - knife.Origin;
			Vector3 proj = Vector3.Project(distToObject, knife.BladeDirection);

			Vector3 collisionPoint = knife.Origin + proj;
			return collisionPoint;
		}
	}
}