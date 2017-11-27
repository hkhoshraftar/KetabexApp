using Foundation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CoreGraphics;
using Ketabex.iOS.CustomView;
using Ketabex.lib;
using Ketabex.Shared.Api;
using Ketabex.Shared.Models;
using ObjCRuntime;
using SQLite;
using UIKit;

namespace Ketabex.iOS
{
    public partial class EmbededtabContentController : UIViewController
    {
        public static PostApi.DataMode Mode = PostApi.DataMode.Latest;
        public static TableQuery<Post> posts;
        public static CollectionSource source;

        public EmbededtabContentController(IntPtr handle) : base(handle)
        {

        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
         

            var postIds = new List<int>();

            string mode = Mode.ToString().ToLower();

            postIds = Database.GetInstance().GetDbCon().Table<PostMode>()
                .Where(q => q.Mode == mode).AsEnumerable().Select(q => q.PostId).ToList();

            posts = Database.GetInstance().GetDbCon().Table<Post>()
                .Where(q => postIds.Contains(q.Id))
                .OrderByDescending(q => q.PublishDate);

            source = new CollectionSource(posts.ToList(),this,CollectionView);

            CollectionView.RegisterNibForCell(PostCollectionViewCell1.Nib, PostCollectionViewCell1.Key);


         
            var flow = new UICollectionViewFlowLayout();
            flow.EstimatedItemSize = new CGSize(View.Frame.Width -10,160);
            flow.ScrollDirection = UICollectionViewScrollDirection.Vertical;
            flow.SectionInset = new UIEdgeInsets(5,5,5,5);
            CollectionView.SetCollectionViewLayout(flow,true);

            CollectionView.DataSource = source;
            CollectionView.ReloadData();
        }


        public class  CollectionSource : UICollectionViewDataSource
        {
            private List<Post> items;
            private UIViewController controller;
            private UICollectionView collection;
    

            public CollectionSource(List<Post> items, UIViewController controller, UICollectionView collection)
            {
                this.items = items;
                this.controller = controller;
                this.collection = collection;
            }


            public override nint GetItemsCount(UICollectionView collectionView, nint section)
            {
                if (items.Any())
                    return items.Count;
                else
                {
                    var label = new UILabel(new CGRect(0, 0, controller.View.Frame.Width, controller.View.Frame.Height));
                    label.Text = "چیزی برای نمایش وجود ندارد";
                    label.TextAlignment = UITextAlignment.Center;
                    label.TextColor = UIColor.Gray;
                    label.SizeToFit();
                    collectionView.BackgroundView = label;
                    return 0;
                }
            }

            public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
            {
                var cell = collectionView.DequeueReusableCell(PostCollectionViewCell1.Key,indexPath) as PostCollectionViewCell1;
                if (cell == null)
                {
                    var arr = NSBundle.MainBundle.LoadNib(PostCollectionViewCell1.Key, null, null);
                    cell = Runtime.GetNSObject<PostCollectionViewCell1>(arr.ValueAt(0));
                }

                cell.Layer.BorderColor = UIColor.LightGray.CGColor;
                cell.Layer.BorderWidth = 0.5f;
                cell.Layer.CornerRadius = 10;
                cell.LayoutMargins = new UIEdgeInsets(5, 5, 5, 5);


                cell.ClipsToBounds = true;
                cell.SetData(items[indexPath.Row]);
                return cell;
            }

            public override nint NumberOfSections(UICollectionView collectionView)
            {
                return 1;
            }
        }
     
    }
}