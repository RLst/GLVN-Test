using System;
using DG.Tweening;
using UnityEngine;

namespace LeMinhHuy
{
	/// <summary>
	/// Detects long range ie. Attacking units
	/// </summary>
	[RequireComponent(typeof(CapsuleCollider))]
	public class LongRangeDetector : MonoBehaviour
	{
		[SerializeField] GameSettings settings;
		[Space]
		[SerializeField] Unit owner;
		[SerializeField] MeshRenderer mr;
		[SerializeField] float scaleUpTime = 0.6f;

		[Header("Detection method")]
		[SerializeField] bool onTriggerEnter = true;
		[SerializeField] bool onTriggerStay = false;
		[SerializeField] bool onTriggerExit = false;

		private CapsuleCollider col;
		Vector3 origScale;

		void Awake()
		{
			col = GetComponent<CapsuleCollider>();
			origScale = transform.localScale;
		}
		void Start()
		{
			Debug.Assert(owner is object, "Detector has no owner");
			Debug.Assert(settings is object, "Game settings not assigned!");

			col.isTrigger = true;
		}

		void OnEnable()
		{
			if (owner.team is null) return;

			this.transform.localScale = origScale;

			//Set detector to the correct size
			var scanWidth = settings.fieldWidth * owner.team.strategy.detectionRange;
			this.transform.DOScaleX(scanWidth, scaleUpTime);
			this.transform.DOScaleZ(scanWidth, scaleUpTime);

			//Try to set the team color of the radar
			SetColor();
		}

		void SetColor()
		{
			if (owner is null) return;
			if (owner.team is null) return;
			mr.material.color = owner.team.color;
		}

		void OnTriggerEnter(Collider other)
		{
			if (!onTriggerEnter) return;
			var unitFound = other.GetComponent<Unit>();
			if (unitFound is object)
				SendMessageUpwards("OnInsideDetectionZone", unitFound);
		}
		void OnTriggerStay(Collider other)
		{
			if (!onTriggerStay) return;
			var unitFound = other.GetComponent<Unit>();
			if (unitFound is object)
				SendMessageUpwards("OnInsideDetectionZone", unitFound);
		}
		void OnTriggerExit(Collider other)
		{
			if (!onTriggerExit) return;
			var unitFound = other.GetComponent<Unit>();
			if (unitFound is object)
				SendMessageUpwards("OnInsideDetectionZone", unitFound);
		}
	}
}