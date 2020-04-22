using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    public readonly struct KinectJointPose
    {
        public Kinect.JointType JointType { get; }

        public Pose pose { get; }
        
        public KinectJointPose(Kinect.JointType type)
        {
            JointType = type;
            pose = Pose.identity;
        }

        public KinectJointPose(Kinect.JointType type, Pose p)
        {
            JointType = type;
            pose = p;
        }
    }
}