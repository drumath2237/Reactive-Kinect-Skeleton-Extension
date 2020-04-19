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

    }
}