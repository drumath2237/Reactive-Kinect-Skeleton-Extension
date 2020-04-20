using System;
using System.Linq;
using UniRx;
using UnityEngine;
using Kinect = Windows.Kinect;

namespace ReactiveKinectExtension
{
//    [RequireComponent(typeof(BodySourceManager))]
    public class ReactiveKinectSkeltonSensor : MonoBehaviour
    {
        [SerializeField] private GameObject bodysourcemanager_obj;
        
        private BodySourceManager _bodySource;

        private ReactiveProperty<KinectSkeletonData> _skeleton;

        public ReactiveProperty<KinectSkeletonData> Skeleton => _skeleton;

        private void Awake()
        {
            _bodySource = bodysourcemanager_obj. GetComponent<BodySourceManager>();
            _skeleton = new ReactiveProperty<KinectSkeletonData>();

        }

        private void Update()
        {
            _bodySource = bodysourcemanager_obj.GetComponent<BodySourceManager>();
            Kinect.Body body = _bodySource.GetData().FirstOrDefault(b => b.IsTracked);
            if (body != null)
            {
                _skeleton.Value = new KinectSkeletonData(body);
            }
        }
    }
}