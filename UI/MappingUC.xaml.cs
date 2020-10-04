using PS3BluMote;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WindowsAPI;

namespace UI
{
    /// <summary>
    /// Lógica de interacción para MappingUC.xaml
    /// </summary>
    public partial class MappingUC : UserControl
    {
        private readonly ObservableCollection<ButtonMapping> buttonMappings = new ObservableCollection<ButtonMapping>();

        public MappingUC()
        {
            InitializeComponent();
            foreach (PS3Remote.Button button in Enum.GetValues(typeof(PS3Remote.Button)))
            {
                buttonMappings.Add(new ButtonMapping(button));
            }

            dgButtons.ItemsSource = buttonMappings;
        }

        private class ButtonMapping: INotifyPropertyChanged
        {
            public PS3Remote.Button Button => button;
            private readonly PS3Remote.Button button;

            private List<SendInputAPI.Keyboard.KeyCode> _mappings;
            public List<SendInputAPI.Keyboard.KeyCode> Mappings 
            {
                get { return _mappings; }
                set 
                {
                    if (_mappings != value) 
                    {
                        _mappings = value;
                        NotifyPropertyChanged();
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public  ButtonMapping(PS3Remote.Button button) 
            {
                this.button = button;

                Mappings = new List<SendInputAPI.Keyboard.KeyCode>();
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            Debug.WriteLine(e.Key);
            e.Handled = true;
        }
    }
}
