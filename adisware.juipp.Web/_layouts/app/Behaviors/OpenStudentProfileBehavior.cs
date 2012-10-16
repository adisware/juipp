using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using adisware.juipp.Events.Arguments;
using adisware.juipp.Web._layouts.app.ViewModels;

namespace adisware.juipp.Web._layouts.app.Behaviors
{
public partial class OpenStudentProfileBehavior
{
    public override void Execute(BehaviorEvent<MyViewModel> args)
    {
        base.Execute(args);

        var userViewModel = 
            this.BehaviorContext["UserViewModel"] as UserViewModel;

        if (userViewModel != null)
        {
            var loginName = userViewModel.LoginName;
            var role = userViewModel.Role;
        }
    }


    public override void Execute(
        BehaviorEvent<StudentViewModel> behaviorEvent)
    {
        StudentEntity entity;
        var id = behaviorEvent.ViewModel.Id;

        using (var data = new EntityModelContainer())
            entity = data.StudentEntities.First(s => s.Id == id);

        behaviorEvent.ViewModel =
            new StudentViewModel()
                {
                    Id = entity.Id,
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email
                };

    }
}
}