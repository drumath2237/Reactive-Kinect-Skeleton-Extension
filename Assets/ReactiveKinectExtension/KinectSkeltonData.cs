using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
    public struct KinectSkeltonData
    {
        public KinectJointPose spineBase;
        public KinectJointPose spineMid;
        public KinectJointPose neck;
        public KinectJointPose head;
        public KinectJointPose shoulderLeft;
        public KinectJointPose elbowLeft;
        public KinectJointPose wristLeft;
        public KinectJointPose handLeft;
        public KinectJointPose shoulderRight;
        public KinectJointPose elbowRight;
        public KinectJointPose wristRight;
        public KinectJointPose handRight;
        public KinectJointPose hipLeft;
        public KinectJointPose kneeLeft;
        public KinectJointPose ankleLeft;
        public KinectJointPose footLeft;
        public KinectJointPose hipRight;
        public KinectJointPose kneeRight;
        public KinectJointPose ankleRight;
        public KinectJointPose footRight;
        public KinectJointPose spineShoulder;

        public void UpdateSkelton(Kinect.Body body)
        {
            spineBase = GetPoseDataFromBody(body, Kinect.JointType.SpineBase);
            spineMid = GetPoseDataFromBody(body, Kinect.JointType.SpineMid);
            neck = get
        }

        private KinectJointPose GetPoseDataFromBody(Kinect.Body body, Kinect.JointType type)
        {
            KinectJointPose res;
            res.jointType = type;
            res.Pose = new Pose(
                KinectTransformDataConverter.KinectData2Position(body.Joints[type]),
                KinectTransformDataConverter.kinectData2Quaternion(body.JointOrientations[type])
            );
            return res;
        }

    }
}