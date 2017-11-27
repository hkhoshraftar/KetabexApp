// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Ketabex.iOS.CustomView
{
    [Register ("PostCollectionViewCell1")]
    partial class PostCollectionViewCell1
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImgAvatar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ImgBookCover { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblBookTitle { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblDescription { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblNickname { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel LblUsername { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImgAvatar != null) {
                ImgAvatar.Dispose ();
                ImgAvatar = null;
            }

            if (ImgBookCover != null) {
                ImgBookCover.Dispose ();
                ImgBookCover = null;
            }

            if (LblBookTitle != null) {
                LblBookTitle.Dispose ();
                LblBookTitle = null;
            }

            if (LblDescription != null) {
                LblDescription.Dispose ();
                LblDescription = null;
            }

            if (LblNickname != null) {
                LblNickname.Dispose ();
                LblNickname = null;
            }

            if (LblUsername != null) {
                LblUsername.Dispose ();
                LblUsername = null;
            }
        }
    }
}