using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Docular.Client.ViewModel
{
    /// <summary>
    /// Represents a container class containing all view models.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// The default <see cref="ViewModelLocator."/>
        /// </summary>
        public static ViewModelLocator Default
        {
            get
            {
                return (ViewModelLocator)System.Windows.Application.Current.Resources["ViewModelLocator"];
            }
        }

        /// <summary>
        /// Gets the <see cref="CategoryViewModel"/>.
        /// </summary>
        public CategoryViewModel CategoryViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CategoryViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="DocumentViewModel"/>.
        /// </summary>
        public DocumentViewModel DocumentViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DocumentViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="LoginViewModel"/>.
        /// </summary>
        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="SearchViewModel"/>.
        /// </summary>
        public SearchViewModel SearchViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="SettingsViewModel"/>.
        /// </summary>
        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="SidebarViewModel"/>.
        /// </summary>
        public SidebarViewModel SidebarViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SidebarViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="StartViewModel"/>.
        /// </summary>
        public StartViewModel StartViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StartViewModel>();
            }
        }

        /// <summary>
        /// Gets the <see cref="TagViewModel"/>.
        /// </summary>
        public TagViewModel TagViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TagViewModel>();
            }
        }

        /// <summary>
        /// Initializes a new <see cref="ViewModelLocator"/>.
        /// </summary>
        public ViewModelLocator()
        {
            Contract.Assume(SimpleIoc.Default != null);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CategoryViewModel>();
            SimpleIoc.Default.Register<DocumentViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<SidebarViewModel>();
            SimpleIoc.Default.Register<StartViewModel>();
            SimpleIoc.Default.Register<TagViewModel>();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        }
    }
}