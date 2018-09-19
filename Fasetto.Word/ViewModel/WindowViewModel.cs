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

        public int ResizeBorder { get; set; } = 6;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder);  } }

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

        public Thickness OuterMarginSizeThickness { get { return new Thickness();  } }
  
        /// <summary>
        /// the radius for the corners 
        /// </summary>
        public int WindowRadius
        {
            get { return mWindow.WindowState == WindowState.Maximized ? 0 : mWindowRadius;  }
            set { mWindowRadius = value;  }
        }
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

            };
        }

        #endregion
    }
}
