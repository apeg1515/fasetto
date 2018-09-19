using PropertyChanged;
using System.ComponentModel;

namespace Fasetto.Word
{
    /// <summary>
    /// a base model that fires property changed as needed
    /// </summary>
    //[ImplementPropertyChanged]
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// the event that is fired when any child property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    
       
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        } 
    }
}
