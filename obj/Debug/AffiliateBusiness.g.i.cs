#pragma checksum "..\..\AffiliateBusiness.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1F2355DA6AE218CDC448F5E509E67F850E012C2403D844456E6695F8CBABC7BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     이 코드는 도구를 사용하여 생성되었습니다.
//     런타임 버전:4.0.30319.42000
//
//     파일 내용을 변경하면 잘못된 동작이 발생할 수 있으며, 코드를 다시 생성하면
//     이러한 변경 내용이 손실됩니다.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using MobileAppUsageDashboard;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MobileAppUsageDashboard {
    
    
    /// <summary>
    /// AffiliateBusiness
    /// </summary>
    public partial class AffiliateBusiness : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DrawerHost mainDrawer;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton CompanyListRadio;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton AffiliateBusinessRadio;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Company_Name_Box;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Campany_Address_Box;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Company_StaffCount_Box;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Star;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Guide_Box;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\AffiliateBusiness.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AffiliateStart_Date_Box;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MobileAppUsageDashboard;component/affiliatebusiness.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AffiliateBusiness.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\AffiliateBusiness.xaml"
            ((MobileAppUsageDashboard.AffiliateBusiness)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.dragME);
            
            #line default
            #line hidden
            return;
            case 2:
            this.mainDrawer = ((MaterialDesignThemes.Wpf.DrawerHost)(target));
            return;
            case 3:
            
            #line 31 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MenuManagementBtnClicked);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 32 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CompanyListBtnClicked);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 33 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OrderInformationBtnClicked);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 34 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShopReviewBtnClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.CompanyListRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 66 "..\..\AffiliateBusiness.xaml"
            this.CompanyListRadio.Click += new System.Windows.RoutedEventHandler(this.CompanyListRadioRadioClicked);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AffiliateBusinessRadio = ((System.Windows.Controls.RadioButton)(target));
            
            #line 70 "..\..\AffiliateBusiness.xaml"
            this.AffiliateBusinessRadio.Click += new System.Windows.RoutedEventHandler(this.AffiliateBusinessRadioClicked);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Company_Name_Box = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Campany_Address_Box = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.Company_StaffCount_Box = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.Star = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.Guide_Box = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 14:
            this.AffiliateStart_Date_Box = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            
            #line 103 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 16:
            
            #line 108 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_4);
            
            #line default
            #line hidden
            return;
            case 17:
            
            #line 112 "..\..\AffiliateBusiness.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.HomeClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

