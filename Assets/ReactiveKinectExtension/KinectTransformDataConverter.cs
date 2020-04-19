using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    public class KinectTransformDataConverter
    {
        static public Vector3 KinectData2Position(Kinect.Joint joint)
        {
            return new Vector3(joint.Position.X, joint.Position.Y, joint.Position.Z);
        }

        static public Quaternion kinectData2Quaternion(Kinect.JointOrientation joint)
        {
            return new Quaternion(joint.Orientation.X, joint.Orientation.Y, joint.Orientation.Z, joint.Orientation.Z);
        }
    }
}