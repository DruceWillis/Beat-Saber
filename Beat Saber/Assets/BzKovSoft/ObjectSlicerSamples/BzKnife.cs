using System;
using System.Collections.Generic;
using UnityEngine;

namespace BzKovSoft.ObjectSlicerSamples
{
	/// <summary>
	/// The script must be attached to a GameObject that have collider marked as a "IsTrigger".
	/// </summary>
	public class BzKnife : MonoBehaviour
	{
		public int SliceID { get; private set; }
		Vector3 _prevPos;
		Vector3 _pos;

		[SerializeField]
		private Vector3 _origin = Vector3.down;

		[SerializeField]
		private Vector3 _direction = Vector3.up;

		private void Update()
		{
			if (Input.GetMouseButton(0))
				this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
			else
				this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

			this.transform.position = Camera.main.ScreenToWorldPoint(new Vector3((Input.mousePosition.x), Input.mousePosition.y, 3.5f));
			// this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.25f, this.transform.position.z);
			
			_prevPos = _pos;
			_pos = transform.position;
		}

		public Vector3 Origin
		{
			get
			{
				Vector3 localShifted = transform.InverseTransformPoint(transform.position) + _origin;
				return transform.TransformPoint(localShifted);
			}
		}

		public Vector3 BladeDirection { get { return transform.rotation * _direction.normalized; } }
		public Vector3 MoveDirection { get { return (_pos - _prevPos).normalized; } }

		public void BeginNewSlice()
		{
			SliceID = SliceIdProvider.GetNewSliceId();
		}
	}
}
