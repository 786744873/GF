using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace CommonClient.Utilities
{
    internal class ExtendTypeString : IExtendType
    {
        public Type GetManagedType()
        {
            return typeof(string);
        }

        public object Copy(object o)
        {
            var s = (string)o;
            return new string(s.ToCharArray());
        }

        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var strStart = (string)start;
            var strEnd = (string)end;

            var iStartLength = strStart.Length;
            var iEndLength = strEnd.Length;
            var iLength = Utility.Interpolate(iStartLength, iEndLength, dPercentage);
            var result = new char[iLength];

            for (int i = 0; i < iLength; ++i)
            {
                var cStart = 'a';
                if (i < iStartLength)
                    cStart = strStart[i];
                var cEnd = 'a';
                if (i < iEndLength)
                    cEnd = strEnd[i];

                char cInterpolated;
                if (cEnd == ' ')
                    cInterpolated = ' ';
                else
                {
                    var iStart = Convert.ToInt32(cStart);
                    var iEnd = Convert.ToInt32(cEnd);
                    var iInterpolated = Utility.Interpolate(iStart, iEnd, dPercentage);
                    cInterpolated = Convert.ToChar(iInterpolated);
                }
                result[i] = cInterpolated;
            }
            return new string(result);
        }
    }

    internal class ExtendTypeInt : IExtendType
    {
        public Type GetManagedType()
        {
            return typeof(int);
        }

        public object Copy(object o)
        {
            var value = (int)o;
            return value;
        }

        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var iStart = (int)start;
            var iEnd = (int)end;
            return Utility.Interpolate(iStart, iEnd, dPercentage);
        }
    }

    internal class ExtendTypeFloat : IExtendType
    {
        public Type GetManagedType()
        {
            return typeof(float);
        }

        public object Copy(object o)
        {
            var f = (float)o;
            return f;
        }

        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var fStart = (float)start;
            var fEnd = (float)end;
            return Utility.Interpolate(fStart, fEnd, dPercentage);
        }
    }

    internal class ExtendTypeColor : IExtendType
    {
        public Type GetManagedType()
        {
            return typeof(Color);
        }

        public object Copy(object o)
        {
            var c = (Color)o;
            var result = Color.FromArgb(c.ToArgb());
            return result;
        }

        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var startColor = (Color)start;
            var endColor = (Color)end;

            int iStartR = startColor.R;
            int iStartG = startColor.G;
            int iStartB = startColor.B;
            int iStartA = startColor.A;

            int iEndR = endColor.R;
            int iEndG = endColor.G;
            int iEndB = endColor.B;
            int iEndA = endColor.A;

            var newR = Utility.Interpolate(iStartR, iEndR, dPercentage);
            var newG = Utility.Interpolate(iStartG, iEndG, dPercentage);
            var newB = Utility.Interpolate(iStartB, iEndB, dPercentage);
            var newA = Utility.Interpolate(iStartA, iEndA, dPercentage);

            return Color.FromArgb(newA, newR, newG, newB);
        }
    }

    internal class ExtendTypeDouble : IExtendType
    {
        public Type GetManagedType()
        {
            return typeof(double);
        }

        public object Copy(object o)
        {
            var d = (double)o;
            return d;
        }

        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            var dStart = (double)start;
            var dEnd = (double)end;
            return Utility.Interpolate(dStart, dEnd, dPercentage);
        }
    }

    public class AnimationTypeUserDefined : IAnimationType
    {
        private double _mDAnimationTime;
        private IList<AnimationElement> _mElements;
        private int _mICurrentElement;

        public AnimationTypeUserDefined()
        {
        }

        public AnimationTypeUserDefined(IList<AnimationElement> elements, int iAnimationTime)
        {
            Setup(elements, iAnimationTime);
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            var dAnimationTimeFraction = iTime / _mDAnimationTime;

            double dElementStartTime;
            double dElementEndTime;
            double dElementStartValue;
            double dElementEndValue;
            InterpolationMethod eInterpolationMethod;
            GetElementInfo(dAnimationTimeFraction, out dElementStartTime, out dElementEndTime, out dElementStartValue, out dElementEndValue, out eInterpolationMethod);

            var dElementInterval = dElementEndTime - dElementStartTime;
            var dElementElapsedTime = dAnimationTimeFraction - dElementStartTime;
            var dElementTimeFraction = dElementElapsedTime / dElementInterval;

            double dElementDistance;
            switch (eInterpolationMethod)
            {
                case InterpolationMethod.Linear:
                    dElementDistance = dElementTimeFraction;
                    break;

                case InterpolationMethod.Accleration:
                    dElementDistance = Utility.ConvertLinearToAcceleration(dElementTimeFraction);
                    break;

                case InterpolationMethod.Deceleration:
                    dElementDistance = Utility.ConvertLinearToDeceleration(dElementTimeFraction);
                    break;

                case InterpolationMethod.EaseInEaseOut:
                    dElementDistance = Utility.ConvertLinearToEaseInEaseOut(dElementTimeFraction);
                    break;

                default:
                    throw new Exception("Interpolation method not handled: " + eInterpolationMethod.ToString());
            }

            dPercentage = Utility.Interpolate(dElementStartValue, dElementEndValue, dElementDistance);

            if (iTime >= _mDAnimationTime)
            {
                bCompleted = true;
                dPercentage = dElementEndValue;
            }
            else bCompleted = false;
        }

        public void Setup(IList<AnimationElement> elements, int iAnimationTime)
        {
            _mElements = elements;
            _mDAnimationTime = iAnimationTime;

            if (elements.Count == 0) throw new Exception("The list of elements passed to the constructor of AnimationType_UserDefined had zero elements. It must have at least one element.");
        }

        private void GetElementInfo(double dTimeFraction, out double dStartTime, out double dEndTime, out double dStartValue, out double dEndValue, out InterpolationMethod eInterpolationMethod)
        {
            var iCount = _mElements.Count;
            for (; _mICurrentElement < iCount; ++_mICurrentElement)
            {
                var element = _mElements[_mICurrentElement];
                var dElementEndTime = element.EndTime / 100.0;
                if (dTimeFraction < dElementEndTime)
                    break;
            }

            if (_mICurrentElement == iCount)
                _mICurrentElement = iCount - 1;

            dStartTime = 0.0;
            dStartValue = 0.0;
            if (_mICurrentElement > 0)
            {
                var previousElement = _mElements[_mICurrentElement - 1];
                dStartTime = previousElement.EndTime / 100.0;
                dStartValue = previousElement.EndValue / 100.0;
            }

            var currentElement = _mElements[_mICurrentElement];
            dEndTime = currentElement.EndTime / 100.0;
            dEndValue = currentElement.EndValue / 100.0;
            eInterpolationMethod = currentElement.InterpolationMethod;
        }
    }

    public class AnimationTypeBounce : AnimationTypeUserDefined
    {
        public AnimationTypeBounce(int iAnimationTime)
        {
            var elements = new List<AnimationElement> { new AnimationElement(50, 100, InterpolationMethod.Accleration), new AnimationElement(100, 0, InterpolationMethod.Deceleration) };
            Setup(elements, iAnimationTime);
        }
    }

    public class AnimationTypeCriticalDamping : IAnimationType
    {
        private readonly double _mDAnimationTime;

        public AnimationTypeCriticalDamping(int iAnimationTime)
        {
            if (iAnimationTime <= 0)
                throw new Exception("UIAnimation time must be greater than zero.");
            _mDAnimationTime = iAnimationTime;
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            var dElapsed = iTime / _mDAnimationTime;
            dPercentage = (1.0 - Math.Exp(-1.0 * dElapsed * 5)) / 0.993262053;

            if (dElapsed >= 1.0)
            {
                dPercentage = 1.0;
                bCompleted = true;
            }
            else
                bCompleted = false;
        }
    }

    public class AnimationTypeDeceleration : IAnimationType
    {
        private readonly double _mDAnimationTime;

        public AnimationTypeDeceleration(int iAnimationTime)
        {
            if (iAnimationTime <= 0)
                throw new Exception("UIAnimation time must be greater than zero.");
            _mDAnimationTime = iAnimationTime;
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            var dElapsed = iTime / _mDAnimationTime;
            dPercentage = dElapsed * (2.0 - dElapsed);
            if (dElapsed >= 1.0)
            {
                dPercentage = 1.0;
                bCompleted = true;
            }
            else
                bCompleted = false;
        }


    }

    public class AnimationTypeEaseInEaseOut : IAnimationType
    {
        private readonly double _mDAnimationTime;

        public AnimationTypeEaseInEaseOut(int iAnimationTime)
        {
            if (iAnimationTime <= 0)
                throw new Exception("UIAnimation time must be greater than zero.");
            _mDAnimationTime = iAnimationTime;
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            var dElapsed = iTime / _mDAnimationTime;
            dPercentage = Utility.ConvertLinearToEaseInEaseOut(dElapsed);

            if (dElapsed >= 1.0)
            {
                dPercentage = 1.0;
                bCompleted = true;
            }
            else
                bCompleted = false;
        }
    }

    public class AnimationTypeFlash : AnimationTypeUserDefined
    {
        public AnimationTypeFlash(int iNumberOfFlashes, int iFlashTime)
        {
            var dFlashInterval = 100.0 / iNumberOfFlashes;
            var elements = new List<AnimationElement>();
            for (int i = 0; i < iNumberOfFlashes; ++i)
            {
                var dFlashStartTime = i * dFlashInterval;
                var dFlashEndTime = dFlashStartTime + dFlashInterval;
                var dFlashMidPoint = (dFlashStartTime + dFlashEndTime) / 2.0;
                elements.Add(new AnimationElement(dFlashMidPoint, 100, InterpolationMethod.EaseInEaseOut));
                elements.Add(new AnimationElement(dFlashEndTime, 0, InterpolationMethod.EaseInEaseOut));
            }

            Setup(elements, iFlashTime * iNumberOfFlashes);
        }
    }

    public class AnimationTypeLinear : IAnimationType
    {
        private readonly double _mDAnimationTime;

        public AnimationTypeLinear(int iAnimationTime)
        {
            if (iAnimationTime <= 0)
                throw new Exception("UIAnimation time must be greater than zero.");
            _mDAnimationTime = iAnimationTime;
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            dPercentage = (iTime / _mDAnimationTime);
            if (dPercentage >= 1.0)
            {
                dPercentage = 1.0;
                bCompleted = true;
            }
            else bCompleted = false;
        }
    }

    public class AnimationTypeThrowAndCatch : AnimationTypeUserDefined
    {
        public AnimationTypeThrowAndCatch(int iAnimationTime)
        {
            var elements = new List<AnimationElement>();
            elements.Add(new AnimationElement(50, 100, InterpolationMethod.Deceleration));
            elements.Add(new AnimationElement(100, 0, InterpolationMethod.Accleration));
            Setup(elements, iAnimationTime);
        }
    }

    public class AnimationTypeAcceleration : IAnimationType
    {
        private readonly double _mDAnimationTime;

        public AnimationTypeAcceleration(int iAnimationTime)
        {
            if (iAnimationTime <= 0)
                throw new Exception("UIAnimation time must be greater than zero.");
            _mDAnimationTime = iAnimationTime;
        }

        public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
        {
            var dElapsed = iTime / _mDAnimationTime;
            dPercentage = dElapsed * dElapsed;
            if (dElapsed >= 1.0)
            {
                dPercentage = 1.0;
                bCompleted = true;
            }
            else
                bCompleted = false;
        }
    }

    internal interface IExtendType
    {
        Type GetManagedType();
        object Copy(object o);
        object GetIntermediateValue(object start, object end, double dPercentage);
    }

    public interface IAnimationType
    {
        void OnTimer(int iTime, out double dPercentage, out bool bCompleted);
    }

    public class UIAnimation
    {
        private static readonly IDictionary<Type, IExtendType> MMapManagedTypes = new Dictionary<Type, IExtendType>();
        private readonly IList<AnimatedPropertyInfo> _mListAnimationedProperties = new List<AnimatedPropertyInfo>();
        private readonly object _mLock = new object();
        private readonly Stopwatch _mStopwatch = new Stopwatch();
        private readonly IAnimationType _mAnimationMethod;

        static UIAnimation()
        {
            RegisterType(new ExtendTypeInt());
            RegisterType(new ExtendTypeFloat());
            RegisterType(new ExtendTypeDouble());
            RegisterType(new ExtendTypeColor());
            RegisterType(new ExtendTypeString());
        }

        public UIAnimation(IAnimationType animationMethod)
        {
            _mAnimationMethod = animationMethod;
        }

        internal IList<AnimatedPropertyInfo> AnimationedProperties
        {
            get { return _mListAnimationedProperties; }
        }

        public event EventHandler<Args> AnimationCompletedEvent;

        public static void Do(object target, string strPropertyName, object destinationValue, IAnimationType animationMethod)
        {
            var t = new UIAnimation(animationMethod);
            t.Add(target, strPropertyName, destinationValue);
            t.Do();
        }

        public static void Do(object target, string strPropertyName, object initialValue, object destinationValue, IAnimationType animationMethod)
        {
            Utility.SetValue(target, strPropertyName, initialValue);
            Do(target, strPropertyName, destinationValue, animationMethod);
        }

        public static void RunChain(params UIAnimation[] uiAnimations)
        {
            new AnimationChain(uiAnimations);
        }

        public void Add(object target, string strPropertyName, object destinationValue)
        {
            var targetType = target.GetType();
            var propertyInfo = targetType.GetProperty(strPropertyName);
            if (propertyInfo == null)
                throw new Exception("Object: " + target + " does not have the property: " + strPropertyName);

            var propertyType = propertyInfo.PropertyType;
            if (MMapManagedTypes.ContainsKey(propertyType) == false)
                throw new Exception("UIAnimation does not handle properties of type: " + propertyType);

            if (propertyInfo.CanRead == false || propertyInfo.CanWrite == false)
                throw new Exception("Property is not both getable and setable: " + strPropertyName);

            var extendType = MMapManagedTypes[propertyType];

            var info = new AnimatedPropertyInfo { EndValue = destinationValue, Target = target, PropertyInfo = propertyInfo, ExtendType = extendType };

            lock (_mLock)
                _mListAnimationedProperties.Add(info);
        }

        public void Do()
        {
            foreach (AnimatedPropertyInfo info in _mListAnimationedProperties)
            {
                object value = info.PropertyInfo.GetValue(info.Target, null);
                info.StartValue = info.ExtendType.Copy(value);
            }
            _mStopwatch.Reset();
            _mStopwatch.Start();
            AnimationManager.GetInstance().Register(this);
        }

        internal void RemoveProperty(AnimatedPropertyInfo info)
        {
            lock (_mLock)
            {
                _mListAnimationedProperties.Remove(info);
            }
        }

        internal void OnTimer()
        {
            var iElapsedTime = (int)_mStopwatch.ElapsedMilliseconds;

            double dPercentage;
            bool bCompleted;
            _mAnimationMethod.OnTimer(iElapsedTime, out dPercentage, out bCompleted);

            var listAnimationedProperties = new List<AnimatedPropertyInfo>();
            lock (_mLock)
            {
                foreach (AnimatedPropertyInfo info in _mListAnimationedProperties)
                {
                    listAnimationedProperties.Add(info.Copy());
                }
            }

            foreach (AnimatedPropertyInfo info in listAnimationedProperties)
            {
                var value = info.ExtendType.GetIntermediateValue(info.StartValue, info.EndValue, dPercentage);
                var args = new PropertyUpdateArgs(info.Target, info.PropertyInfo, value);
                SetProperty(this, args);
            }

            if (bCompleted)
            {
                _mStopwatch.Stop();
                Utility.RaiseEvent(AnimationCompletedEvent, this, new Args());
            }
        }


        private void SetProperty(object sender, PropertyUpdateArgs args)
        {
            if (isDisposed(args.Target))
                return;

            var invokeTarget = args.Target as ISynchronizeInvoke;
            if (invokeTarget != null && invokeTarget.InvokeRequired)
            {
                IAsyncResult asyncResult = invokeTarget.BeginInvoke(new EventHandler<PropertyUpdateArgs>(SetProperty), new[] { sender, args });
                asyncResult.AsyncWaitHandle.WaitOne(50);
            }
            else
                args.PropertyInfo.SetValue(args.Target, args.Value, null);
        }

        private bool isDisposed(object target)
        {
            var controlTarget = target as Control;
            if (controlTarget == null)
                return false;
            if (controlTarget.IsDisposed || controlTarget.Disposing)
                return true;
            return false;
        }

        private static void RegisterType(IExtendType AnimationType)
        {
            Type type = AnimationType.GetManagedType();
            MMapManagedTypes[type] = AnimationType;
        }

        public class Args : EventArgs
        {
        }

        private class PropertyUpdateArgs : EventArgs
        {
            public readonly PropertyInfo PropertyInfo;
            public readonly object Target;
            public readonly object Value;

            public PropertyUpdateArgs(object t, PropertyInfo pi, object v)
            {
                Target = t;
                PropertyInfo = pi;
                Value = v;
            }
        }

        internal class AnimatedPropertyInfo
        {
            public object EndValue;
            public IExtendType ExtendType;
            public PropertyInfo PropertyInfo;
            public object StartValue;
            public object Target;

            public AnimatedPropertyInfo Copy()
            {
                var info = new AnimatedPropertyInfo { StartValue = StartValue, EndValue = EndValue, Target = Target, PropertyInfo = PropertyInfo, ExtendType = ExtendType };
                return info;
            }
        }
    }

    internal class AnimationManager
    {
        private static AnimationManager _mInstance;
        private readonly object _mLock = new object();
        private readonly Timer _mTimer;
        private readonly IDictionary<UIAnimation, bool> _mAnimations = new Dictionary<UIAnimation, bool>();

        private AnimationManager()
        {
            _mTimer = new Timer(15);
            _mTimer.Elapsed += OnTimerElapsed;
            _mTimer.Enabled = true;
        }

        public static AnimationManager GetInstance()
        {
            return _mInstance ?? (_mInstance = new AnimationManager());
        }

        public void Register(UIAnimation uiAnimation)
        {
            lock (_mLock)
            {
                RemoveDuplicates(uiAnimation);
                _mAnimations[uiAnimation] = true;
                uiAnimation.AnimationCompletedEvent += OnAnimationCompleted;
            }
        }

        private void RemoveDuplicates(UIAnimation uiAnimation)
        {
            foreach (var pair in _mAnimations)
            {
                RemoveDuplicates(uiAnimation, pair.Key);
            }
        }

        private void RemoveDuplicates(UIAnimation newUiAnimation, UIAnimation oldUiAnimation)
        {
            var newProperties = newUiAnimation.AnimationedProperties;
            var oldProperties = oldUiAnimation.AnimationedProperties;

            for (int i = oldProperties.Count - 1; i >= 0; i--)
            {
                var oldProperty = oldProperties[i];
                foreach (UIAnimation.AnimatedPropertyInfo newProperty in newProperties)
                {
                    if (oldProperty.Target == newProperty.Target && oldProperty.PropertyInfo == newProperty.PropertyInfo)
                        oldUiAnimation.RemoveProperty(oldProperty);
                }
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_mTimer == null)
                return;
            _mTimer.Enabled = false;

            IList<UIAnimation> listAnimations;
            lock (_mLock)
            {
                listAnimations = new List<UIAnimation>();
                foreach (var pair in _mAnimations)
                {
                    listAnimations.Add(pair.Key);
                }
            }

            foreach (UIAnimation Animation in listAnimations)
            {
                Animation.OnTimer();
            }

            _mTimer.Enabled = true;
        }

        private void OnAnimationCompleted(object sender, UIAnimation.Args e)
        {
            var Animation = (UIAnimation)sender;
            Animation.AnimationCompletedEvent -= OnAnimationCompleted;

            lock (_mLock)
            {
                _mAnimations.Remove(Animation);
            }
        }
    }

    public enum InterpolationMethod
    {
        Linear,
        Accleration,
        Deceleration,
        EaseInEaseOut
    }

    public class AnimationElement
    {
        public AnimationElement(double endTime, double endValue, InterpolationMethod interpolationMethod)
        {
            EndTime = endTime;
            EndValue = endValue;
            InterpolationMethod = interpolationMethod;
        }

        public double EndTime { get; set; }

        public double EndValue { get; set; }

        public InterpolationMethod InterpolationMethod { get; set; }
    }

    internal class AnimationChain
    {
        private readonly LinkedList<UIAnimation> _mListAnimations = new LinkedList<UIAnimation>();

        public AnimationChain(params UIAnimation[] uiAnimations)
        {
            foreach (UIAnimation Animation in uiAnimations)
            {
                _mListAnimations.AddLast(Animation);
            }

            RunNextAnimation();
        }

        private void RunNextAnimation()
        {
            if (_mListAnimations.Count == 0)
                return;
            var nextAnimation = _mListAnimations.First.Value;
            nextAnimation.AnimationCompletedEvent += OnAnimationCompleted;
            nextAnimation.Do();
        }

        private void OnAnimationCompleted(object sender, UIAnimation.Args e)
        {
            var Animation = (UIAnimation)sender;
            Animation.AnimationCompletedEvent -= OnAnimationCompleted;

            _mListAnimations.RemoveFirst();
            RunNextAnimation();
        }
    }

    internal class Utility
    {
        public static object GetValue(object target, string strPropertyName)
        {
            var targetType = target.GetType();
            var propertyInfo = targetType.GetProperty(strPropertyName);
            if (propertyInfo == null)
                throw new Exception("Object: " + target + " does not have the property: " + strPropertyName);
            return propertyInfo.GetValue(target, null);
        }

        public static void SetValue(object target, string strPropertyName, object value)
        {
            var targetType = target.GetType();
            var propertyInfo = targetType.GetProperty(strPropertyName);
            if (propertyInfo == null)
                throw new Exception("Object: " + target + " does not have the property: " + strPropertyName);
            propertyInfo.SetValue(target, value, null);
        }

        public static double Interpolate(double d1, double d2, double dPercentage)
        {
            var dDifference = d2 - d1;
            var dDistance = dDifference * dPercentage;
            var dResult = d1 + dDistance;
            return dResult;
        }

        public static int Interpolate(int i1, int i2, double dPercentage)
        {
            return (int)Interpolate(i1, (double)i2, dPercentage);
        }

        public static float Interpolate(float f1, float f2, double dPercentage)
        {
            return (float)Interpolate(f1, (double)f2, dPercentage);
        }

        public static double ConvertLinearToEaseInEaseOut(double dElapsed)
        {
            var dFirstHalfTime = (dElapsed > 0.5) ? 0.5 : dElapsed;
            var dSecondHalfTime = (dElapsed > 0.5) ? dElapsed - 0.5 : 0.0;
            var dResult = 2 * dFirstHalfTime * dFirstHalfTime + 2 * dSecondHalfTime * (1.0 - dSecondHalfTime);
            return dResult;
        }

        public static double ConvertLinearToAcceleration(double dElapsed)
        {
            return dElapsed * dElapsed;
        }

        public static double ConvertLinearToDeceleration(double dElapsed)
        {
            return dElapsed * (2.0 - dElapsed);
        }

        public static void RaiseEvent<T>(EventHandler<T> theEvent, object sender, T args) where T : EventArgs
        {
            if (theEvent == null)
                return;

            foreach (EventHandler<T> handler in theEvent.GetInvocationList())
            {
                var target = handler.Target as ISynchronizeInvoke;
                if (target == null || target.InvokeRequired == false)
                    handler(sender, args);
                else
                    target.BeginInvoke(handler, new[] { sender, args });
            }
        }
    }
}