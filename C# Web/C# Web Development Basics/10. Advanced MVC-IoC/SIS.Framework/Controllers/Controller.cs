﻿namespace SIS.Framework.Controllers
{
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Utilities;
    using SIS.Framework.Views;
    using SIS.Framework.ViewModel;
    using SIS.HTTP.Requests.Contracts;
    using System.Runtime.CompilerServices;

    public abstract class Controller
    {
        protected ViewModel Model { get; set; }

        protected Controller()
        {
            this.Model = new ViewModel();
        }

        public Model ModelState { get; } = new Model();

        public IHttpRequest Request { get; set; }

        protected IViewable View([CallerMemberName] string caller = "")
        {
            string controllerName = ControllerUtilities.GetControllerName(this);

            string fullyQualifiedName = ControllerUtilities
                .GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
              => new RedirectResult(redirectUrl);
     
    }
}
