using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityEventSprite : UnityEvent<Sprite> { }

[Serializable]
public class UnityEventInt : UnityEvent<int> { }

[Serializable]
public class UnityEventFloat : UnityEvent<float> { }