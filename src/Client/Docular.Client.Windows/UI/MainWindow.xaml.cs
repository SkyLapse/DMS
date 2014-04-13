using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Contracts;
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
using Docular.Client.Core.Model;
using Docular.Client.Core.Model.Rest;

namespace Docular.Client.Windows.UI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.LoadSkinFromSettings();
            InitializeComponent();
        }

        private void LoadSkinFromSettings()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.PerUserRoamingAndLocal);
            DocularSection section = (DocularSection)config.GetSection(DocularSection.SectionXmlKey);

            Contract.Assume(section != null);
            ((App)Application.Current).UpdateSkin(new Uri(String.Format("Resources/Skins/{0}.xaml", section.Skin), UriKind.Relative));
        }
    }
}
