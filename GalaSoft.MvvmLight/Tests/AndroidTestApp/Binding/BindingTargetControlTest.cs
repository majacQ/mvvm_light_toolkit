using System;
using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Test.ViewModel;
using NUnit.Framework;
#if ANDROID
using Android.App;
using Android.Widget;

#elif __IOS__
using GalaSoft.MvvmLight.Test.Controls;

#endif

namespace GalaSoft.MvvmLight.Test.Binding
{
    [TestFixture]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class BindingTargetControlTest
    {
        private Helpers.Binding _binding;

#if ANDROID
        public EditText _target;
        private EditText _targetPrivate;

        private EditText TargetPrivate
        {
            get;
            set;
        }

        public EditText Target
        {
            get;
            private set;
        }
#elif __IOS__
        public UITextViewEx _target;
        private UITextViewEx _targetPrivate;

        public UITextViewEx Target
        {
            get;
            private set;
        }

        private UITextViewEx TargetPrivate
        {
            get;
            set;
        }
#endif

        public TestViewModel VmSource
        {
            get;
            private set;
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                Target,
                () => Target.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                TargetPrivate,
                () => TargetPrivate.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _target,
                () => _target.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _targetPrivate,
                () => _targetPrivate.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithVar_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            var target = new EditText(Application.Context);
#elif __IOS__
            var target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                target,
                () => target.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => Target.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateProperty_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => TargetPrivate.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _target.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateField_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _targetPrivate.Text);

            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicPropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                Target,
                () => Target.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, Target.Text);
            newValue += "Suffix";
            Target.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivatePropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                TargetPrivate,
                () => TargetPrivate.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, TargetPrivate.Text);
            newValue += "Suffix";
            TargetPrivate.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPublicFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _target,
                () => _target.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, _target.Text);
            newValue += "Suffix";
            _target.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithPrivateFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                _targetPrivate,
                () => _targetPrivate.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, _targetPrivate.Text);
            newValue += "Suffix";
            _targetPrivate.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_NewBindingWithVarTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            var target = new EditText(Application.Context);
#elif __IOS__
            var target = new UITextViewEx();
#endif

            _binding = new Binding<string, string>(
                VmSource,
                () => VmSource.Model.StringProperty,
                target,
                () => target.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, target.Text);
            newValue += "Suffix";
            target.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicPropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            Target = new EditText(Application.Context);
#elif __IOS__
            Target = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => Target.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, Target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, Target.Text);
            newValue += "Suffix";
            Target.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivatePropertyTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            TargetPrivate = new EditText(Application.Context);
#elif __IOS__
            TargetPrivate = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => TargetPrivate.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, TargetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, TargetPrivate.Text);
            newValue += "Suffix";
            TargetPrivate.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPublicFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _target = new EditText(Application.Context);
#elif __IOS__
            _target = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _target.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, _target.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, _target.Text);
            newValue += "Suffix";
            _target.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }

        [Test]
        public void BindingTargetControl_SetBindingWithPrivateFieldTwoWay_NoError()
        {
            VmSource = new TestViewModel
            {
                Model = new TestModel
                {
                    StringProperty = "Initial value"
                }
            };

#if ANDROID
            _targetPrivate = new EditText(Application.Context);
#elif __IOS__
            _targetPrivate = new UITextViewEx();
#endif

            _binding = this.SetBinding(
                () => VmSource.Model.StringProperty,
                () => _targetPrivate.Text,
                BindingMode.TwoWay);

            Assert.AreEqual(VmSource.Model.StringProperty, _targetPrivate.Text);
            var newValue = DateTime.Now.Ticks.ToString();
            VmSource.Model.StringProperty = newValue;
            Assert.AreEqual(newValue, _targetPrivate.Text);
            newValue += "Suffix";
            _targetPrivate.Text = newValue;
            Assert.AreEqual(newValue, VmSource.Model.StringProperty);
        }
    }
}