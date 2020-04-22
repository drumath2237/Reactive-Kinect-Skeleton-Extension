using System;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    public struct KinectSkeletonData
    {
        private KinectJointPose[] Joints {  get;  set; }

        public KinectSkeletonData(Kinect.Body body)
        {
            Joints = new KinectJointPose[25];
            for (var i = 0; i < 25; i++)
            {
                Joints[i] = CreatePoseDataFromBody(body, (Kinect.JointType)Enum.ToObject(typeof(Kinect.JointType), i));
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
            foreach (var joint in Joints)
            {
                if (joint.jointType == type) return joint;
            }
            return new KinectJointPose();
        }

        public KinectJointPose this[Kinect.JointType type] => GetJointPose(type);
    }
}