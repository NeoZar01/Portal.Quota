using System;
using System.Collections.Generic;

namespace DoE.Quota.Web.Models
{
    using DoE.Core.Web.Models;

    public abstract class HomeViewModel : BaseViewModel<HomeViewModel>
    {

        public HomeViewModel(string view) 
        : base(view) {}
    }

    public class AdmnistratorHomeViewModel : HomeViewModel
    {
        public AdmnistratorHomeViewModel(string view) : base(view) {}

        public override void 
        Execute() { this.Execute(); }
    }

    public class SchoolHomePageViewModel : HomeViewModel
    {
        public SchoolHomePageViewModel(string view) : base(view) {}

        public override void
        Execute()
        { this.Execute(); }

        public string SchoolName { get; set; }
    }
}