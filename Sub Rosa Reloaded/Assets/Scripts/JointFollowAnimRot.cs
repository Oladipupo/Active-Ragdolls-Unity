using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointFollowAnimRot : MonoBehaviour {

	public bool invert;

	public float torqueForce;
	public float angularDamping;
	public float maxForce;
	public float springForce;
	public float springDamping;

	public Vector3 targetVel;

	public Transform target;
	private GameObject limb;
	private JointDrive drive;
	private SoftJointLimitSpring spring;
	private ConfigurableJoint joint;
	private Quaternion startingRotation;

	void Start () {

		torqueForce = 500f;
		angularDamping = 0.0f;
		maxForce = 500f;

		springForce = 0f;
		springDamping = 0f;

		targetVel = new Vector3(0f, 0f, 0f);

		drive.positionSpring = torqueForce;
		drive.positionDamper = angularDamping;
		drive.maximumForce = maxForce;

		spring.spring = springForce;
		spring.damper = springDamping;

		joint = gameObject.GetComponent<ConfigurableJoint>();

		joint.slerpDrive = drive;

		joint.linearLimitSpring = spring;
		joint.rotationDriveMode = RotationDriveMode.Slerp;
		joint.projectionMode = JointProjectionMode.None;
		joint.targetAngularVelocity = targetVel;
		joint.configuredInWorldSpace = false;
		joint.swapBodies = true;

		joint.angularXMotion = ConfigurableJointMotion.Free;
		joint.angularYMotion = ConfigurableJointMotion.Free;
		joint.angularZMotion = ConfigurableJointMotion.Free;
		joint.xMotion = ConfigurableJointMotion.Locked;
		joint.yMotion = ConfigurableJointMotion.Locked;
		joint.zMotion = ConfigurableJointMotion.Locked;

		startingRotation = Quaternion.Inverse(target.localRotation);
	}

	void LateUpdate () {
		if (invert) 
			joint.targetRotation = Quaternion.Inverse(target.localRotation * startingRotation);
		else
			joint.targetRotation = target.localRotation * startingRotation;
	}


}