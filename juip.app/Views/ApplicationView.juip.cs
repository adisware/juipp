using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using juip.Events.Arguments;
using juip.Events.Handlers;
using juip.Views;
using juip.app.ViewModels;

namespace juip.app.Views
{
    //StudentViewModel
    public partial class ApplicationView : IActionPerformer<StudentViewModel>
    {
        private ActionPerformedHandler<StudentViewModel> _studentViewModelActionPerformed;
        event ActionPerformedHandler<StudentViewModel> IActionPerformer<StudentViewModel>.ActionPerformed
        {
            add
            {
                _studentViewModelActionPerformed += value;
                base.RaiseActionEventDelegates.Add(args => base.RaiseActionEvent(_studentViewModelActionPerformed, args as ActionPerformedEventArgs<StudentViewModel>));
            }
            remove { if (_studentViewModelActionPerformed != null) _studentViewModelActionPerformed -= value; }
        }
    }

    //CourseViewModel
    public partial class ApplicationView : IActionPerformer<CourseViewModel>
    {
        private ActionPerformedHandler<CourseViewModel> _courseViewModelActionPerformed;
        event ActionPerformedHandler<CourseViewModel> IActionPerformer<CourseViewModel>.ActionPerformed
        {
            add
            {
                _courseViewModelActionPerformed += value;
                base.RaiseActionEventDelegates.Add(args => base.RaiseActionEvent(_courseViewModelActionPerformed, args as ActionPerformedEventArgs<CourseViewModel>));
            }
            remove { if (_courseViewModelActionPerformed != null) _courseViewModelActionPerformed -= value; }
        }
    }

    //RegistrationViewModel
    public partial class ApplicationView : IActionPerformer<RegistrationViewModel>
    {
        private ActionPerformedHandler<RegistrationViewModel> _registrationViewModelActionPerformed;
        event ActionPerformedHandler<RegistrationViewModel> IActionPerformer<RegistrationViewModel>.ActionPerformed
        {
            add
            {
                _registrationViewModelActionPerformed += value;
                base.RaiseActionEventDelegates.Add(args => base.RaiseActionEvent(_registrationViewModelActionPerformed, args as ActionPerformedEventArgs<RegistrationViewModel>));
            }
            remove { if (_studentViewModelActionPerformed != null) _registrationViewModelActionPerformed -= value; }
        }
    }
}