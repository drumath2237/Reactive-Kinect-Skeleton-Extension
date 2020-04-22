using System;
using UniRx;
using UnityEditor;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectSkeletonExtension.Sample
{
    [RequireComponent(typeof(ReactiveKinectSkeletonSensor))]
    public class SampleSkeletonView : MonoBehaviour
    {
        private KinectSkeletonData _skeletonData;
        private ReactiveKinectSkeletonSensor _sensor;
        private void Start()
        {
            _sensor = GetComponent<ReactiveKinectSkeletonSensor>();
            
            _sensor.Skeleton.Subscribe(skeleton =>
            {
                _skeletonData = skeleton;
            }).AddTo(gameObject);
        }
        
        private void OnDrawGizmos()
        {
            if (!EditorApplication.isPlaying) return;
            for (var i = 0; i < 21; i++)
            {
                Gizmos.DrawWireSphere(_skeletonData[(Kinect.JointType)Enum.ToObject(typeof(Kinect.JointType),i)].pose.position, 0.05f);
            }
        }
    }
}