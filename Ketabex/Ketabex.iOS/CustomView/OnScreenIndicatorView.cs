using System;
using System.Collections.Generic;
using System.Text;
using UIKit;

namespace Ketabex.iOS.CustomView
{
    public class OnScreenIndicatorView : UIActivityIndicatorView
    {
        private UIView hostView;

        public OnScreenIndicatorView(UIView hostView)
        {
            this.hostView = hostView;
        }

        public void Show()
        {
            this.Color = UIColor.Gray;
            this.HidesWhenStopped = true;
            this.Center = hostView.Center;
            hostView.AddSubview(this);
        }

        public void Hide()
        {
            this.Hide();
        }
    }
}
