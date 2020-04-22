using System;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
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
        
        private KinectJointPose CreatePoseDataFromBody(Kinect.Body body, Kinect.JointType type)
        {
            KinectJointPose res;
            res.jointType = type;
            res.pose = new Pose(
                KinectTransformDataConverter.KinectData2Position(body.Joints[type]),
                KinectTransformDataConverter.KinectData2Quaternion(body.JointOrientations[type])
            );
            return res;
        }

        private KinectJointPose GetJointPose(Kinect.JointType type)
        {
            return _joints[(int) type];
        }

        public KinectJointPose this[Kinect.JointType type] => GetJointPose(type);
    }
}