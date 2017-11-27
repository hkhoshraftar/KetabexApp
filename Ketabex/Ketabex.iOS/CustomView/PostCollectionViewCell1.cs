using System;
using FFImageLoading;
using FFImageLoading.Work;
using Foundation;
using Ketabex.Shared.Models;
using UIKit;

namespace Ketabex.iOS.CustomView
{
    public partial class PostCollectionViewCell1 : UICollectionViewCell
    {
        public static readonly NSString Key = new NSString("PostCollectionViewCell1");
        public static readonly UINib Nib;

        static PostCollectionViewCell1()
        {
            Nib = UINib.FromName("PostCollectionViewCell1", NSBundle.MainBundle);
        }

        protected PostCollectionViewCell1(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void SetData(Post post)
        {
            ImageService.Instance.LoadUrl(post.BookCoverUrl + "?v=" + post.Id)
                .FadeAnimation(true)
                .LoadingPlaceholder("Splash2",ImageSource.ApplicationBundle)
                .Into(ImgBookCover);

            ImageService.Instance.LoadUrl(post.Avatar + "?v=" + post.Id)
                .FadeAnimation(true)
                .Into(ImgAvatar);


            LblBookTitle.Text = post.BookTitle;
            LblDescription.Text = post.Description;
            LblNickname.Text = post.Nickname;
            LblUsername.Text = "@" + post.Username;


            ImgAvatar.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            {
                
            }));


        }
    }
}