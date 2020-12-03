using RoofrackDataAccess;
using RoofrackDataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetVips;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel;
using System.Windows.Threading;

namespace RoofrackDataManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _log;

        public string Log
        {
            get { return _log; }
            set
            {
                if (string.Equals(value, _log))
                    return;
                _log = value;
                OnPropertyChanged("Log");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void LoadImages_Click(object sender, RoutedEventArgs e)
        {
            var textBoxPathValue = textBoxPath.Text;
            var thumbnailSizeValue = thumbnailSize.Value;
            await Task.Run(() => LoadImages(textBoxPathValue, thumbnailSizeValue.Value));


        }

        private void LoadImages(string imagePath, int thumbnailSize)
        {
            using (var context = new NopCommerceDbContext())
            {
                var directories = Directory.GetDirectories(imagePath);
                foreach (var directory in directories)
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(directory);

                    var siteProducts = context.Products.Where(p => p.ManufacturerPartNumber == directoryInfo.Name).ToList();

                    foreach (var siteProduct in siteProducts)
                    {

                        Log = siteProduct.Name + "\r\n" + Log;

                        if (siteProduct != null)
                        {
                            var productPictures = siteProduct.Product_Picture_Mapping;
                            foreach (var productPicture in productPictures.ToList())
                            {
                                var binaries = context.PictureBinaries.Where(pb => pb.PictureId == productPicture.PictureId);
                                foreach (var binary in binaries)
                                {
                                    context.PictureBinaries.Remove(binary);
                                }

                                context.Pictures.Remove(productPicture.Picture);
                            }

                            productPictures.Clear();

                            var files = directoryInfo.GetFiles("*.*");

                            foreach (var file in files)
                            {
                                if (file.Extension.ToLower() == ".png" || file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".jpeg")
                                {
                                    var fileExtension = file.Extension.ToLower();
                                    if (fileExtension == ".jpeg")
                                    {
                                        fileExtension = ".jpg";
                                    }

                                    NetVips.Image smallerImage = NetVips.Image.Thumbnail(file.FullName, thumbnailSize);

                                    var picture = new Picture() { MimeType = $"image/{fileExtension.Replace(".", "")}" };
                                    context.Pictures.Add(picture);
                                    context.SaveChanges();

                                    var data = new PictureBinary()
                                    {
                                        PictureId = picture.Id,
                                        BinaryData = smallerImage.WriteToBuffer($"{fileExtension}")
                                    };
                                    context.PictureBinaries.Add(data);

                                    siteProduct.Product_Picture_Mapping.Add(new Product_Picture_Mapping()
                                    {
                                        PictureId = picture.Id
                                    });

                                }
                            }

                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        private void UnpublishEmptyCategories_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new NopCommerceDbContext())
            {
                List<Category> leavesAndParents = new List<Category>();
                List<Category> leafCategories = GetLeafNodes(context.Categories.Where(c => c.ParentCategoryId == 0).ToList(), context);
                List<int> categorieToUnpublish = new List<int>();
                foreach (var leaf in leafCategories)
                {
                    leavesAndParents.Add(leaf);
                    leavesAndParents.AddRange(GetLeafAndParents(leaf, context));
                }

                var distinctLeavesAndParents = leavesAndParents.Distinct(new CategoryComparer());

                var categories = context.Categories;
                foreach (var category in categories)
                {
                    if (leavesAndParents.Any(c => c.Id == category.Id))
                    {

                    }
                    else
                    {
                        categorieToUnpublish.Add(category.Id);
                    }
                }

                foreach (var categoryId in categorieToUnpublish)
                {
                    var category = context.Categories.Find(categoryId);
                    category.Published = false;
                    context.SaveChanges();
                }
            }

        }

        private IEnumerable<Category> GetLeafAndParents(Category leaf, NopCommerceDbContext context)
        {
            List<Category> parents = new List<Category>();

            if (leaf.ParentCategoryId == 0)
            {
                return parents;
            }
            else
            {
                parents.Add(leaf.ParentCategory);
                parents.AddRange(GetLeafAndParents(leaf.ParentCategory, context));
                return parents;
            }
        }

        private List<Category> GetLeafNodes(List<Category> categories, NopCommerceDbContext context)
        {
            List<Category> leafCategories = new List<Category>();

            foreach (var category in categories)
            {
                var numberOfProducts = context.Product_Category_Mapping.Where(pcm => pcm.CategoryId == category.Id).Count();


                if (numberOfProducts > 0)
                {
                    leafCategories.Add(category);
                }
                else
                {
                    var leaves = context.Categories.Where(c => c.ParentCategoryId == category.Id).ToList();
                    leafCategories.AddRange(GetLeafNodes(leaves, context));
                }
            }

            return leafCategories;
        }

        private class CategoryComparer : IEqualityComparer<Category>
        {
            public bool Equals([AllowNull] Category x, [AllowNull] Category y)
            {
                return x.Id == y.Id;
            }

            public int GetHashCode([DisallowNull] Category obj)
            {
                return obj.GetHashCode();
            }
        }

        private void removeLogo_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new NopCommerceDbContext())
            {
                var products = context.Products.Where(p => p.Product_Manufacturer_Mapping.Any(m => m.Manufacturer.Name == manufacturer.Text)).ToList();

                foreach (var product in products)
                {
                    if (product.Product_Category_Mapping.Any(m => m.Category.Name == category.Text))
                    {

                    }
                    else if (product.Product_Picture_Mapping.Count() > 0)
                    {
                        var picture = product.Product_Picture_Mapping.First();
                        var pictureBinary = context.PictureBinaries.Where(pb => pb.PictureId == picture.PictureId).First();
                        var image = NetVips.Image.NewFromBuffer(pictureBinary.BinaryData);
                        var colour = image.Getpoint(image.Width - 1, 1);
                        var newImage = image.DrawRect(colour, image.Width / 2, image.Height - 60, image.Width / 2, 60, true);
                        pictureBinary.BinaryData = newImage.JpegsaveBuffer();

                        context.SaveChanges();
                    }
                }
            }
        }
        private void MatchAndLoadImages_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
