using System;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectSkeletonExtension
{
    public readonly struct KinectSkeletonData
    {
        private readonly KinectJointPose[] _joints;

        public KinectSkeletonData(Kinect.Body body)
        {
            var types = Enum.GetValues(typeof(Kinect.JointType));
            _joints = new KinectJointPose[types.Length];

            foreach (var joint in types)
            {
                _joints[(int) joint] = CreatePoseDataFromBody(body, (Kinect.JointType)joint);
            }
        }

        public KinectSkeletonData(KinectJointPose[] joints)
        {
            if (joints.Length != Enum.GetNames(typeof(Kinect.JointType)).Length)
                throw new Exception("invalid joint for construct skeleton.");

            _joints = joints;
        }
        
        private KinectJointPose CreatePoseDataFromBody(Kinect.Body body, Kinect.JointType type)
        {
            var p = new Pose(
                KinectTransformDataConverter.KinectData2Position(body.Joints[type]),
                KinectTransformDataConverter.KinectData2Quaternion(body.JointOrientations[type])
            );

            return new KinectJointPose(type, p);
        }

        private KinectJointPose GetJointPose(Kinect.JointType type)
        {
            return _joints[(int) type];
        }
        public KinectJointPose this[Kinect.JointType type] => GetJointPose(type);

        public KinectSkeletonData ToMirror()
        {
            KinectJointPose[] poses = new KinectJointPose[Enum.GetNames(typeof(Kinect.JointType)).Length];
            foreach (var j in _joints)
            {
                poses[(int)j.JointType] = new KinectJointPose(j.JointType, new Pose(
                    j.pose.position,
                    new Quaternion(j.pose.rotation.x, -j.pose.rotation.y, -j.pose.rotation.z, j.pose.rotation.w)
                    ));
            }
            return new KinectSkeletonData(poses);
        }
    }
}