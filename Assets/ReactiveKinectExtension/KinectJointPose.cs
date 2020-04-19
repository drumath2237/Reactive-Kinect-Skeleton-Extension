using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    public struct KinectJointPose
    {
        public Kinect.JointType jointType;
        public Pose Pose;
    }
}