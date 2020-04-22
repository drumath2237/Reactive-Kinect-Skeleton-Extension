# Reactive Kinect Skeleton Extension

**注意：このドキュメントはまだ未完成です。**

## About

Kinect v2で取得した骨格データをリアクティブに通知するための簡単なユーティリティです。

あとUnityで使いやすいようにKinect.Vector4みたいな値などをPose構造体に変換したりしてます。(そのせいで独自のデータ構造を作っています。)

## Requirements

- Kinect For Windows Unity Pro
- UniRx

## Tested Env

- Unity 2019.3.1
- [KinectForWindows_UnityPro 2.0.1410](https://developer.microsoft.com/ja-jp/windows/kinect/)
- [UniRx 7.1.0](https://github.com/neuecc/UniRx/releases/tag/7.1.0)

- Windows Home
- Intel Core-i7 7700
- GeForce GTX 1060

## Install

[Releaseページ](https://github.com/drumath2237/Reactive-Kinect-Skeleton-Extension/releases)のunitypackageをDLします。

1. Unityを開く
2. Kinect SDKパッケージを導入します。
   1. zipに入ってる「KinectView」フォルダをPluginsに入れるのも忘れずに
3. UniRxをいれる
4. このパッケージを入れる

## Usage

空のGameObjectをシーンに追加し、'ReactiveKinectSkeletonSensor'コンポーネントをアタッチします。
このGameObjectからGetComponentすれば、ReactivePropertyとして全身の骨格データ(KinectSkeletonData)が取得でき、センサーデータに変更があれば登録されたObserverに通知されます。

例えば下のような書き方ができます。(Skeletonデータをメンバ変数に格納するだけのプログラム)

```csharp
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
```

## Contact

何か問題があれば、作者の[Twitter(@ninisan_drumath)](https://twitter.com/ninisan_drumath)へご連絡いただくか、
issueやPRをください。
