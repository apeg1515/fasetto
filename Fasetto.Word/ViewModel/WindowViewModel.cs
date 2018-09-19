using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows;

namespace Fasetto.Word
{
    /// <summary>
    /// the view model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        private Window mWindow;
        private int _size_ = 6;
        private int _title_ = 42;

        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;
        /// <summary>
        /// the radius of the corners
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Public Properties

        //public int ResizeBorder { get; set; } = 6;
        public int ResizeBorder {
            get { return _size_; }
            set { _size_ = value; }
        }
        /// <summary>
        /// the size of the resize border around te window, outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize);  } }

        /// <summary>
        /// the margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mOuterMarginSize;  }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize);  } }
  
        /// <summary>
        /// the radius for the corners 
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;  }
            set { mWindowRadius = value;  }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight
        {
            get { return _title_; }
            set { _title_ = value; }
        }

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder);  } }

        #endregion

        #region Contrustor
        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // listen to the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // fire off events for all properties that effected by the resize (5)
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };
        }

        #endregion
    }
}
