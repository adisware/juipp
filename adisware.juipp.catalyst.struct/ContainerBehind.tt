<#@ template debug="false" hostspecific="true" language="C#" #>
<#@ output extension=".cs" #>
<#= "using System;" #>
<#= "using System.Collections.Generic;" #>
<#= "using adisware.juipp.Behaviors;" #>
<#= "using $rootnamespace$.Views;" #>
<#= "using $rootnamespace$.Behaviors;" #>
<#= "using $rootnamespace$.Controllers;" #>
<#= "using adisware.juipp.Views;" #>
<#= "using adisware.juipp.Controllers;" #>

namespace <#= "$rootnamespace$.Controllers" #> 
{ 
    public static class ControllerReference
    {
             <#
                var controllers = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Controllers\"));
                foreach(var controller in controllers)
                {
                    var fileName = System.IO.Path.GetFileName(controller);
                    var className =  fileName.Split('.')[0];
                    if(fileName.EndsWith("Controller.cs")) 
					{
             #>public const string <#= className #> = "<#= className #>";
             <#}
			 }
			 #>
    }

    public partial class <#= "Container" #> : ContainerBase
    {
	           <#
                //var controllers = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Controllers\"));
                foreach(var controller in controllers)
                {
                    var fileName = System.IO.Path.GetFileName(controller);
                    var className =  fileName.Split('.')[0];
                    if(fileName.EndsWith("Controller.cs")) 
				{#>
				protected ControllerBase <#= className #>;
				<#}
                }
             #>

           <#
                var views = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Views\"));
                foreach(var view in views)
                {
                    var fileName = System.IO.Path.GetFileName(view);
                    var className =  fileName.Split('.')[0];
                    if(fileName.EndsWith("View.ascx.cs") == false) continue;
             #> 
             protected global::$rootnamespace$.Views.<#= className #> <#= className #>;
             <#
                }
             #>

        protected override void OnInit(EventArgs e) 
        { 
		     <#
                //var controllers = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Controllers\"));
                foreach(var controller in controllers)
                {
                    var fileName = System.IO.Path.GetFileName(controller);
                    var className =  fileName.Split('.')[0];

                     if(fileName.EndsWith("Controller.cs")) 
					 {
             #> 
			             base.Controllers.Add(new KeyValuePair<string, ControllerBase>(
                                      ControllerReference.<#= className #>,
                                      new <#= className #>(this) { ID = "<#= className #>" }));
             <#}
                }
             #>

		    
             base.OnInit(e);

             base.Behaviors = new Dictionary<String, IBehavior>();

             <# 
                var behaviors = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Behaviors\"));
                foreach(var behavior in behaviors)
                {
                    var fileName =  System.IO.Path.GetFileName(behavior);
                    var className =  fileName.Split('.')[0];
                    if(fileName.EndsWith("Behavior.cs") == false) continue;
             #> 
                 base.Behaviors.Add(new KeyValuePair<string, IBehavior>(
                                        BehaviorReference.<#= className #>, 
                                        new <#= className #>() { BehaviorContext = this } ));
             <#
                }
             #>


            base.Views = new Dictionary<string, ViewBase>();

             <#
                //var views = System.IO.Directory.GetFiles(Host.ResolvePath(@"..\Views\"));
                foreach(var view in views)
                {
                    var fileName = System.IO.Path.GetFileName(view);
                    var className =  fileName.Split('.')[0];
                    if(fileName.EndsWith("View.ascx.cs") == false) continue;
             #> 
                 base.Views.Add(new KeyValuePair<string, ViewBase>(
                                        ViewReference.<#= className #>,  
                                        this.<#= className #> ));
             <#
                }
             #>
        }
    }
} 

